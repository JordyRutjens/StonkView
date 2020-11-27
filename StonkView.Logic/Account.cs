using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StonkView.Logic
{
    public class Account
    {
        public void ValidateLogin()
        {
            Console.WriteLine("Initial");
            MySqlConnection conn = new MySqlConnection("Data Source=localhost;Initial Catalog=StonkView;Integrated Security=True;Pooling=False");

            conn.ConnectionString = "Data Source=localhost;Initial Catalog=StonkView;Integrated Security=True;Pooling=False";
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();

            //INSERT INTO users(`Name`,`Password`) VALUES(?name,?password)
            comm.CommandText = "INSERT INTO `account`(`accountName`, `accountPassword`, `accountMail`, `accountID`) VALUES('testName', 'testPassword','testMail', '2')";
            //comm.Parameters.Add("?name", MySqlDbType.VarChar).Value = "JRUT";
            //comm.Parameters.Add("?password", MySqlDbType.VarChar).Value = "HIOJOI";
            comm.ExecuteNonQuery();


            MySqlCommand cmd = null;
            string cmdString = "";
            conn.Open();

            cmdString = "INSERT INTO `account`(`accountName`, `accountPassword`, `accountMail`, `accountID`) VALUES('testName', 'testPassword','testMail', '2')";

            cmd = new MySqlCommand(cmdString, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            Console.WriteLine("Data Stored Successfully");

        }
    }
}
