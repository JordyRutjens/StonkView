using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using StonkView.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using StonkView.DataAccess;
using System.Configuration;

namespace StonkView.DataAccess
{
    public class FavoriteDAL
    {
        private MySqlConnection conn = new MySqlConnection("datasource = 127.0.0.1; port=3306;username=root;password=usbw;database=stonkview");

        public void addFavoriteStockToAccount(string ticker, int accountID)
        {
            string cmdString = "INSERT INTO `accountfavorites` (`favoriteTicker`, `favoriteAddDate`, `favoriteAccountID`) VALUES(@ticker,@date,@id)";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            conn.Open();
            DateTime date = DateTime.Now; 
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@id", accountID);
            cmd.Parameters.AddWithValue("@ticker", ticker);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
