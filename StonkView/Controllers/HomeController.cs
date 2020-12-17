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
using StonkView.Logic;


namespace StonkView.Controllers
{

    public class HomeController : Controller
    {       
        Account account = new Account();

        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            account.AccountUsername();
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
            account.CreateAccount(accountSignUp.accountUsername, accountSignUp.accountPassword,accountSignUp.accountEmail);
            return View("Index");
        }

        public IActionResult Login(AccountModel accountLogin)
        {
            account.ValidateLogin(accountLogin.accountUsername, accountLogin.accountPassword);
            account.AccountUsername();
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
