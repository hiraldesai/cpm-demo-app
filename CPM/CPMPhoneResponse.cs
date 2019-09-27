using Newtonsoft.Json;
using System.Collections.Generic;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class CPMPhoneResponse : CPMResponse
    {
        [JsonProperty("identity")]
        public PhoneIdentity Identity { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
