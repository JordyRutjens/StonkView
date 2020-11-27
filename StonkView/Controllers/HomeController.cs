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
using static StonkView.Models.StockModel;

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
            //Logic.News.LoadNews();
            //ViewData["News"] = Logic.News.news;
            return View();
        }
        public IActionResult Stocks()
        {
            Logic.Stock.LoadStocks();
            ViewData["StockList"] = Logic.Stock.stocks;
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

            //MySqlConnection conn = new MySqlConnection("Data Source=localhost;Initial Catalog=StonkView;Integrated Security=True;Pooling=False");

            //MySqlCommand cmd;
            //string cmdString;
            //conn.Open();

            //cmdString = "INSERT INTO `account`(`accountName`, `accountPassword`, `accountMail`, `accountID`) VALUES('testName', 'testPassword','testMail', '2')";

            //cmd = new MySqlCommand(cmdString, conn);
            //cmd.ExecuteReader();

            //conn.Close();
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
