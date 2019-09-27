using Newtonsoft.Json;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class PhoneIdentity
    {
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("name")]
        public NameSettings Name { get; set; }
    }
}
