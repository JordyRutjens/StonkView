﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StonkView.Models
{
    public class AccountModel
    {
        public int UserId { get; private set; }
        public string accountUsername { get; set; }
        public string accountEmail { get; set; }
        public string accountPassword { get; set; }
    }
}
