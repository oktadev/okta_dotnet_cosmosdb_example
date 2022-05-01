using Newtonsoft.Json;

namespace Okta_CosmosDb.Models
{
    public class ScrubResult
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "person")]
        public Person Person { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        public ScrubResult(Person person, bool success)
        {
            Person = person;
            Success = success;
            Id = Guid.NewGuid().ToString();
        }
    }
}
