﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StonkView.DataAccess;
using StonkView.Models;
using StonkView.Factory;
using StonkView.Inferface;

namespace StonkView.Logic
{
    public class Account : IAccount
    {
        
        private IAccountDAL account = AccountFactory.GetDAL();
            
        public void SetConnection(string connectionString)
        {
            account.SetConnection(connectionString);
        }
        public void CreateAccount(string username, string password, string email)
        {
            account.CreateAccount(username, password, email);
        }

        public void ValidateLogin(string username, string password)
        {
            account.GetAccount(username, password);
        }

        public string AccountUsername()
        {
            string output;
            if (account.GetUsername() == "0")
            {
                output = "Failed to login!";
            }
            else
            {
                output = "Welcome, " + account.GetUsername() + "!";
            }
            UserModel.accountUsername = output;
            return output;
        }
        public int AccountID()
        {
            return UserModel.accountID = account.GetAccountID();
        }
    }
}
