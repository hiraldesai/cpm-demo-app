using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CPM_Dotnet_Core
{
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly string _clientId;
        private readonly string _clientKey;
        private readonly string _resource;
        private readonly string _authority;

        private AuthenticationResult _token = null;
        private HttpResponseMessage _lastMsg = null;

        public AuthenticatedHttpClientHandler(AADConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(AADConnection));

            _clientId = connection.ClientId;
            _clientKey = connection.ClientKey;
            _resource = connection.Resource;

            _authority = $"{connection.Authority}/{connection.Tenant}";
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_token == null || _token.ExpiresOn <= DateTimeOffset.UtcNow.AddMinutes(-5))
                _token = await GetAccessToken();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token?.AccessToken);
            _lastMsg = await base.SendAsync(request, cancellationToken);

            if (_lastMsg.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                _token = null; //set the token to null

            return _lastMsg;
        }

        private async Task<AuthenticationResult> GetAccessToken()
        {
            var authContext = new AuthenticationContext(_authority);

            return await authContext.AcquireTokenAsync(_resource, new ClientCredential(_clientId, _clientKey));
        }
    }
}
