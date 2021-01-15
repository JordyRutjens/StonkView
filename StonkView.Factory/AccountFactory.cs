﻿using System;
using System.Collections.Generic;
using System.Text;
using StonkView.DataAccess;
using StonkView.Inferface;

namespace StonkView.Factory
{
    public class AccountFactory
    {
        public static IAccountDAL GetDAL()
        {
            return new AccountDAL();
        }
    }
}
