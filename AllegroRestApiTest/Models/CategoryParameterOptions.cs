using Newtonsoft.Json;
using System.Collections.Generic;

namespace AllegroRestApiTest.Models
{
    class CategoryParameterOptions
    {
        [JsonProperty("variantsAllowed")]
        public bool VariantsAllowed { get; set; }

        [JsonProperty("variantsEqual")]
        public bool VariantsEqual { get; set; }

        [JsonProperty("ambiguousValueId")]
        public string AmbiguousValueId { get; set; }

        [JsonProperty("dependsOnParameterId")]
        public string DependsOnParameterId { get; set; }

        [JsonProperty("requiredDependsOnValueIds")]
        public List<string> RequiredDependsOnValueIds { get; set; }

        [JsonProperty("displayDependsOnValueIds")]
        public List<string> DisplayDependsOnValueIds { get; set; }

        [JsonProperty("describesProduct")]
        public bool DescribesProduct { get; set; }

        [JsonProperty("customValuesEnabled")]
        public bool CustomValuesEnabled { get; set; }
    }
}
