using Newtonsoft.Json;

namespace Services
{
    public class SendNumberRequest
    {
        [JsonProperty("number")]
        public int Number { get; set; }
    }
}
