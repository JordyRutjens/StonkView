using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using StonkView.Models;

namespace StonkView.Logic
{
    public class News
    {
        public static StonkView.Models.NewsModel.NewsArray[] news;
        public static void LoadNews()
        {
            using (var webClient = new WebClient())
            {
                String jsonString = webClient.DownloadString("http://newsapi.org/v2/everything?domains=wsj.com&apiKey=3d9659ce7cf74257b487ddb0021835ce");
                var news = NewsModel.NewsArray.FromJson(jsonString);
            }
        }
    }
}

