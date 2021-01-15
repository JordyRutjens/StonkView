using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using StonkView.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StonkView.Inferface;
using StonkView.Factory;

namespace StonkView.Logic
{
    public class News : INewsDAL
    {
        private INewsDAL news = NewsFactory.GetDAL();
        public NewsModel.NewsArray[] LoadNews()
        {
            return news.LoadNews();
        }
    }
}

