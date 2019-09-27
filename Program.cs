using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CPM_Dotnet_Core
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            var aadConnection = new AADConnection
            {
                Authority = config["Authority"],
                ClientId = config["ClientId"],
                ClientKey = config["ClientKey"],
                Resource = config["CPMResourceId"],
                Tenant = config["Tenant"]
            };

            var serviceCollection = new ServiceCollection()
                                    .AddSingleton<IConfiguration>(config)
                                    .AddSingleton(aadConnection)
                                    .AddLogging();

            serviceCollection.AddRefitClient<ICPMApi>()
                    .ConfigurePrimaryHttpMessageHandler(() => new AuthenticatedHttpClientHandler(aadConnection))
                    .ConfigureHttpClient(c =>
                    {
                        c.BaseAddress = new Uri(config["CPMUri"]);
                    });

            var services = serviceCollection.BuildServiceProvider();

            var cpmApi = services.GetService<ICPMApi>();

            try
            {
                var phoneResult = await cpmApi.GetPhoneContacts("+13105314066", "Jean-François", "Desai");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting phone contact: {e.Message}");
            }

            try
            {
                var addressResult = await cpmApi.GetAddressContacts("John", "Smith", ": Salvador-Allende-Straße 20", "", "Rhône", "FR", "1234", "FR");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting address contact: {e.Message}");
            }

            try
            {
                var emailResult = await cpmApi.GetEmailContacts("juana-díaz@microsoft.com");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting email contact: {e.Message}");
            }


            using (var httpClient = new HttpClient(new AuthenticatedHttpClientHandler(aadConnection)))
            {
                httpClient.BaseAddress = new Uri(config["CPMUri"]);

                httpClient.DefaultRequestHeaders.Add("x-ms-filter-first-name", "Jean-François");
                httpClient.DefaultRequestHeaders.Add("x-ms-filter-last-name", "Desai");
                httpClient.DefaultRequestHeaders.Add("x-ms-filter-phone-number", "+13105314066");

                try
                {
                    var response = await httpClient.GetAsync("/api/PhoneContacts");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error getting email contact even with a standard http client: {e.Message}");
                }
            }

            Console.WriteLine("Done");
        }
    }
}
