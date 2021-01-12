using Newtonsoft.Json;

namespace AllegroRestApiTest.Models
{
    class CategoryParameterRestrictions
    {
        [JsonProperty("min")]
        public int? Min { get; set; }

        [JsonProperty("max")]
        public int? Max { get; set; }

        [JsonProperty("minLength")]
        public int? MinLength { get; set; }

        [JsonProperty("maxLength")]
        public int? MaxLength { get; set; }

        [JsonProperty("range")]
        public bool? Range { get; set; }

        [JsonProperty("precision")]
        public int? Precision { get; set; }

        [JsonProperty("allowedNumberOfValues")]
        public int? AllowedNumberOfValues { get; set; }

        [JsonProperty("multipleChoices")]
        public bool? MultipleChoices { get; set; }
    }
}
