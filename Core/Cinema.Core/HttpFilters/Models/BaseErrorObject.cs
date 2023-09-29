using Cinema.Core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cinema.Core.HttpFilters.Models
{
    public class BaseErrorObject
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorLevel ErrorLevel { get; internal set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ActionFingerprint ActionFingerprint { get; internal set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Messages { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<JObject> Data { get; set; }
    }
}
