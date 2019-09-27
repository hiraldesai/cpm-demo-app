using Newtonsoft.Json;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class EmailResponse : CPMResponse
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
