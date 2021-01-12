using Newtonsoft.Json;
using System.Collections.Generic;

namespace AllegroRestApiTest.Models
{
    class CategoryList
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }
    }
}
