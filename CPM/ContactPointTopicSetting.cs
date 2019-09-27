using Newtonsoft.Json;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class ContactPointTopicSetting
    {
        [JsonProperty("cultureName")]
        public string CultureName { get; set; }
        [JsonProperty("lastSourceSetDate")]
        public string LastSourceSetDate { get; set; }
        [JsonProperty("originalSource")]
        public string OriginalSource { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("topicId")]
        public string TopicId { get; set; }
        [JsonProperty("isVerified")]
        public string IsVerified { get; set; }

        public static ContactPointTopicSetting DefaultSettings = new ContactPointTopicSetting
        {
            CultureName = "en-US",
            IsVerified = false.ToString()
        };
    }

}
