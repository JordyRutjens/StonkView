using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using StonkView.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StonkView.Inferface;

namespace StonkView.DataAccess
{
    public class NewsDAL : INewsDAL
    {
        public NewsModel.NewsArray[] LoadNews()
        {
            using (var webClient = new WebClient())
            {
                String jsonString = webClient.DownloadString("http://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=3d9659ce7cf74257b487ddb0021835ce");
                var jobj = JObject.Parse(jsonString);
                var data = JsonConvert.DeserializeObject<NewsModel.NewsArray[]>(jobj["articles"].ToString());
                return data;
            }
        }
    }
}
