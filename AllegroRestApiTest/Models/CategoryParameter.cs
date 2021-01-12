using Newtonsoft.Json;
using System.Collections.Generic;

namespace AllegroRestApiTest.Models
{
    class CategoryParameter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("requiredForProduct")]
        public bool RequiredForProduct { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("options")]
        public CategoryParameterOptions Options { get; set; }

        [JsonProperty("restrictions")]
        public CategoryParameterRestrictions Restrictions { get; set; }

        [JsonProperty("dictionary")]
        public List<CategoryParameterDictionary> Dictionary { get; set; }
    }
}
