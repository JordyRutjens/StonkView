using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StonkView.Models
{
    public class StockModel
    {
        public partial class StockArray
        {
            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Sector")]
            public string Sector { get; set; }

            [JsonProperty("Symbol")]
            public string Symbol { get; set; }
        }

        public partial class StockArray
        {
            public StockArray[] FromJson(string json) => JsonConvert.DeserializeObject<StockArray[]>(json);
        }
    }
}

