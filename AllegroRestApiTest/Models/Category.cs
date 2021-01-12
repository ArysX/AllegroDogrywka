using Newtonsoft.Json;

namespace AllegroRestApiTest.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("options")]
        public CategoryOptionsDto Options { get; set; }

        [JsonProperty("Parent")]
        public CategoryParent Parent { get; set; }
    }
}
