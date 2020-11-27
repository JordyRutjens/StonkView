using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StonkView.Models;

namespace StonkView.Controllers
{
    public class AccountController : Controller
    {

        //private static MySqlConnection conn;

        //public ActionResult Post_CreateAccount(string username, string password)
        //{
        //    Console.WriteLine("Initial");

        //    conn.ConnectionString = "Data Source=localhost;Initial Catalog=StonkView;Integrated Security=True;Pooling=False";
        //    conn.Open();
        //    MySqlCommand comm = conn.CreateCommand();

        //    //INSERT INTO users(`Name`,`Password`) VALUES(?name,?password)
        //    comm.CommandText = "INSERT INTO `account`(`accountName`, `accountPassword`, `accountMail`, `accountID`) VALUES('testName', 'testPassword','testMail', '2')";
        //    //comm.Parameters.Add("?name", MySqlDbType.VarChar).Value = "JRUT";
        //    //comm.Parameters.Add("?password", MySqlDbType.VarChar).Value = "HIOJOI";
        //    comm.ExecuteNonQuery();

        //}
    }
}

