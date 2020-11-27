using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StonkView.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Net;

namespace StonkView.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public void OnGet()
        {
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    String jsonString = webClient.DownloadString("http://newsapi.org/v2/everything?domains=wsj.com&apiKey=3d9659ce7cf74257b487ddb0021835ce");
                    var news = NewsModel.NewsArray.FromJson(jsonString);
                    ViewData["HomePage"] = news;
                }
                catch
                {
                    return View();
                }          
            }
            return View();
        }
        public IActionResult Stocks()
        {
            using (var webClient = new WebClient())
            {
                String jsonString = webClient.DownloadString("https://pkgstore.datahub.io/core/s-and-p-500-companies/constituents_json/data/8fd832966a715a70cb9cf3f723498e3b/constituents_json.json");
                var stocks = StockModel.StockArray.FromJson(jsonString);
                ViewData["StockList"] = stocks;
            }

            return View();
        }
        public IActionResult StockDetails()
        {
            return View();
        }
        public IActionResult AddTicker()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }
        public IActionResult AccountManagement()
        {
            AccountModel accountViewModel = new AccountModel();
            return View(accountViewModel);
        }

        public IActionResult SignUp(AccountModel accountSignUp)
        {
            Console.WriteLine(accountSignUp.accountUsername + "SIGNUP");
            Console.WriteLine(accountSignUp.accountPassword + "SIGNUP");

            MySqlConnection conn = new MySqlConnection("Data Source=localhost;Initial Catalog=StonkView;Integrated Security=True;Pooling=False");

            MySqlCommand cmd;
            string cmdString;
            conn.Open();

            cmdString = "INSERT INTO `account`(`accountName`, `accountPassword`, `accountMail`, `accountID`) VALUES('testName', 'testPassword','testMail', '2')";

            cmd = new MySqlCommand(cmdString, conn);
            cmd.ExecuteReader();

            conn.Close();
            return View("Index");
        }

        public IActionResult Login(AccountModel accountLogin)
        {
            Console.WriteLine(accountLogin.accountUsername + "SIGNIN");
            Console.WriteLine(accountLogin.accountPassword + "SIGNIN");

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
