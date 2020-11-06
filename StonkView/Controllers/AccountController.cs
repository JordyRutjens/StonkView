using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StonkView.Controllers
{
    public class AccountController
    {
        MySqlConnection conn;

        void getConnection()
        {
            conn.ConnectionString = "datasource=localhost;port=3307;username=root;password=usbw;database=stonkview";
        }
        public void ValidateLogin()
        {
            conn = new MySqlConnection("");
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();

            //INSERT INTO users(`Name`,`Password`) VALUES(?name,?password)
            comm.CommandText = "INSERT INTO `users`(`Name`, `Password`) VALUES('Test', 'TEST2')";
            //comm.Parameters.Add("?name", MySqlDbType.VarChar).Value = "JRUT";
            //comm.Parameters.Add("?password", MySqlDbType.VarChar).Value = "HIOJOI";
            comm.ExecuteNonQuery();
        }
    }
}

