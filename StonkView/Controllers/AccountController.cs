using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StonkView.Models;
using StonkView.Logic;
using Microsoft.Extensions.Configuration;
using System.IO;
using StonkView.DataAccess;

namespace StonkView.MVC.Controllers
{
    public class AccountController : Controller
    {
        Account account = new Account();

        public IActionResult Account()
        {
            ViewData["LoggedAccountUsername"] = UserModel.accountUsername;
            ViewData["LoggedAccountID"] = UserModel.accountID;
            return View();
        }
        private void GetConnectionString()
        {
            var builder = new
            ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",
            optional: true, reloadOnChange: true);
            string _connectionString = builder.Build().GetSection("ConnectionStrings").GetSection("DatabaseConnection").Value;
            account.SetConnection(_connectionString);
        }

        public IActionResult AccountManagement()
        {
            if (UserModel.accountID > 0)
            {
                return RedirectToAction("Account", "Account");
            }
            GetConnectionString();
            AccountModel accountViewModel = new AccountModel();
            return View(accountViewModel);
        }

        public IActionResult SignUp(AccountModel accountSignUp)
        {
            GetConnectionString();
            account.CreateAccount(accountSignUp.accountUsername, accountSignUp.accountPassword, accountSignUp.accountEmail);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login(AccountModel accountLogin)
        {
            GetConnectionString();
            account.ValidateLogin(accountLogin.accountUsername, accountLogin.accountPassword);
            account.AccountUsername();
            account.AccountID();
            return RedirectToAction("Index", "Home");
        }
    }
}