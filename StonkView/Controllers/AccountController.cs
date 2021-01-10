using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StonkView.Models;
using StonkView.Logic;
using Microsoft.Extensions.Configuration;

namespace StonkView.MVC.Controllers
{
    public class AccountController : Controller
    {
        Account account = new Account();

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
            account.CreateAccount(accountSignUp.accountUsername, accountSignUp.accountPassword, accountSignUp.accountEmail);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login(AccountModel accountLogin)
        {
            account.ValidateLogin(accountLogin.accountUsername, accountLogin.accountPassword);
            account.AccountUsername();
            account.AccountID();
            ViewData["LoggedAccountID"] = UserModel.accountID;
            ViewData["LoggedAccountUsername"] = UserModel.accountUsername;
            return RedirectToAction("Index", "Home");
        }
    }
}