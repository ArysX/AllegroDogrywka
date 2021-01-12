using Newtonsoft.Json;

namespace AllegroRestApiTest.Models
{
    public class CategoryOptionsDto
    {
        [JsonProperty("advertisement")]
        public bool Advertisement { get; set; }

        [JsonProperty("advertisementPriceOptional")]
        public bool AdvertisementPriceOptional { get; set; }

        [JsonProperty("variantsByColorPatternAllowed")]
        public bool VariantsByColorPatternAllowed { get; set; }

        [JsonProperty("offersWithProductPublicationEnabled")]
        public bool OffersWithProductPublicationEnabled { get; set; }

        [JsonProperty("productCreationEnabled")]
        public bool ProductCreationEnabled { get; set; }

        [JsonProperty("productEANRequired")]
        public bool ProductEANRequired { get; set; }

        [JsonProperty("customParametersEnabled")]
        public bool CustomParametersEnabled { get; set; }
    }
}
