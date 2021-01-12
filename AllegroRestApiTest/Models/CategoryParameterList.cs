using Newtonsoft.Json;
using System.Collections.Generic;

namespace AllegroRestApiTest.Models
{
    class CategoryParameterList
    {
        [JsonProperty("parameters")]
        public List<CategoryParameter> Parameters { get; set; }
    }
}
