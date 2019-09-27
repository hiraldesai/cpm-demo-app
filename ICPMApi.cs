using NonprofitPlatform.Core.BusinessModel.CPM;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPM_Dotnet_Core
{
    public interface ICPMApi
    {
        [Get("/api/EmailContacts")]
        Task<CPMEmailResponse> GetEmailContacts([Header("x-ms-filter-email")]string email);

        [Get("/api/PhoneContacts")]
        Task<List<CPMPhoneResponse>> GetPhoneContacts([Header("x-ms-filter-phone-number")]string phoneNumber, [Header("x-ms-filter-first-name")]string firstName, [Header("x-ms-filter-last-name")]string lastName);

        [Get("/api/AddressContacts")]
        Task<CPMAddressResponse> GetAddressContacts([Header("x-ms-filter-first-name")]string firstName, [Header("x-ms-filter-last-name")]string lastName, [Header("x-ms-filter-address-line1")]string addressLine1, [Header("x-ms-filter-address-line2")]string addressLine2, [Header("x-ms-filter-address-city")]string addressCity, [Header("x-ms-filter-address-state")] string addressState, [Header("x-ms-filter-address-postalcode")] string postalCode, [Header("x-ms-filter-address-country")]string addressCountry);

        [Patch("/api/EmailContacts")]
        Task<CPMEmailResponse> PatchEmailContacts([Body] CPMEmailResponse cpmEmailResponse);

        [Patch("/api/PhoneContacts")]
        Task PatchPhoneContacts([Body] CPMPhoneResponse cpmPhoneResponse);

        [Patch("/api/AddressContacts")]
        Task PatchAddressContacts([Body] CPMAddressResponse cpmAddressResponse);
    }


}
