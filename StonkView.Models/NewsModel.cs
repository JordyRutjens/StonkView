using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StonkView.Models
{
    public class NewsModel
    {
        public partial class NewsArray
        {
            [JsonProperty("titel")]
            public string Titel { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public partial class NewsArray
        {
            public static NewsArray[] FromJson(string json) => JsonConvert.DeserializeObject<NewsArray[]>(json);
        }
    }
}
