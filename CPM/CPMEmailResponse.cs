using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class CPMEmailResponse
    {
        private object cpmResponse;

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("topicSettings")]
        public List<ContactPointTopicSetting> TopicSettings { get; set; }
    }
}
