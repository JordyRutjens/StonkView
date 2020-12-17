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
            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("description")]
            public string description { get; set; }

            [JsonProperty("url")]
            public string url { get; set; }

            [JsonProperty("urlToImage")]
            public string urlToImage { get; set; }

            [JsonProperty("content")]
            public string content { get; set; }

            [JsonProperty("publishedAt")]
            public string publishedAt { get; set; }
        }

        public partial class NewsArray
        {
            public NewsArray[] FromJson(string json) => JsonConvert.DeserializeObject<NewsArray[]>(json);
        }
    }
}
