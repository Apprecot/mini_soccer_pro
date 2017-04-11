using Newtonsoft.Json;

namespace MiniSoccerPro.Models
{
    public class ServiceResponse
    {
        [JsonProperty(PropertyName = "rs")]
        public int StatusCode { get; set; }
        [JsonProperty(PropertyName = "rm")]
        public string Message { get; set; }

        // Deserialized Data
        public object Data { get; set; }
        // Non Deserialized
        public string Json { get; set; }
    }
}
