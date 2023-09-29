using Newtonsoft.Json;

namespace Cinema.Core.HttpFilters.Models
{
    public class BaseResultObject<T>
    {
        public Guid RequestId { get; set; }

        public DateTime TimeStamp { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Payload { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public BaseErrorObject Errors { get; set; }
    }
}