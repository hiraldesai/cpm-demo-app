using Newtonsoft.Json;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class CPMAddressResponse : CPMResponse
    {
        [JsonProperty("identity")]
        public AddressIdentity Identity { get; set; }
    }
}
