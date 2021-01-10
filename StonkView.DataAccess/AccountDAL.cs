using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 

namespace StonkView.DataAccess
{
    public class AccountDAL
    {
        private MySqlConnection conn = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=usbw;database=stonkview");
        private int accountID;
        public int GetAccountID()
        {
            return accountID;
        }

        private int GetLastMadeID()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(accountID) FROM `account`", conn);
            int id = Convert.ToInt32(cmd.ExecuteScalar().ToString() == "" ? 0 : cmd.ExecuteScalar());
            return id;
        }
        public void CreateAccount(string username, string password, string email)
        {
            int id = GetLastMadeID() + 1;
            string cmdString = "INSERT INTO `account`(`accountName`, `accountPassword`, `accountMail`, `accountID`) VALUES(@username,@password,@email,@id)";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public string GetUsername()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT `accountName` FROM `account` WHERE `accountID` = @accountID", conn);
            cmd.Parameters.AddWithValue("@accountID", accountID);

            string username;

            if (cmd.ExecuteScalar() == null)
            {
                username = "Couldn't find user";
            }
            else
            {
                username = Convert.ToString(cmd.ExecuteScalar().ToString() == "" ? 0 : cmd.ExecuteScalar());
            }
            conn.Close();
            return username;
        }

        public int GetAccount(string username, string password)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT `accountID` FROM `account` WHERE `accountName` = @username AND `accountPassword` = @password", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            int id;

            if (cmd.ExecuteScalar() == null)
            {
                id = 0;
            }
            else
            {
                id = Convert.ToInt32(cmd.ExecuteScalar().ToString() == "" ? 0 : cmd.ExecuteScalar());
            }
            accountID = id;
            conn.Close();
            return accountID;
        }
    }
}
