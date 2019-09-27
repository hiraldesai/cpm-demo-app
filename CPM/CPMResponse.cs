using Newtonsoft.Json;
using System.Collections.Generic;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class CPMResponse
    {
        [JsonProperty("topicSettings")]
        public List<ContactPointTopicSetting> TopicSettings { get; set; }
    }
}
