using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StonkView.Models;
using StonkView.Logic;

namespace StonkView.Controllers
{
    public class NewsController : Controller
    {
        News news = new News();

        public IActionResult News()
        {            
            ViewData["News"] = news.LoadNews();
            return View();
        }
    }
}