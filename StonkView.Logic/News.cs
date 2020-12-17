using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using StonkView.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StonkView.Logic
{
    public class News
    {
        DataAccess.NewsDAL news = new DataAccess.NewsDAL();
        public NewsModel.NewsArray[] LoadNews()
        {
            return news.LoadNews();
        }
    }
}

