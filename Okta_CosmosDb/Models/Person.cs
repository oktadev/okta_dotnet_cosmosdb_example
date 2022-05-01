using Newtonsoft.Json;

namespace Okta_CosmosDb.Models
{
    public class Person
    {
        public string Name { get; set; }

        [JsonIgnore]
        public string SSN { get; set; }
    }
}
