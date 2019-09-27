using Newtonsoft.Json;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class NameSettings
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }
        [JsonProperty("generationalSuffix")]
        public string GenerationalSuffix { get; set; }
    }
}
