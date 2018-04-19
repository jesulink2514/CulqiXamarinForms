using Newtonsoft.Json;

namespace CardDemoXamarin.Culqi
{
    public class CulqiPaymentResponse
    {
        [JsonProperty("object")]
        public string ResponseType { get; set; }
        public string type { get; set; }
        public string id { get; set; }
    }
}
