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
using StonkView.Inferface;

namespace StonkView.DataAccess
{
    public class FavoriteDAL : IFavoriteDAL
    {
        private MySqlConnection conn;

        public void SetConnection(string connectionString)
        {
            conn = new MySqlConnection(connectionString);
        }
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

        public List<string> getFavoriteStockFromAccount(int accountID)
        {
            string cmdString = "SELECT `favoriteTicker` FROM `accountfavorites` WHERE `favoriteAccountID` = @id";
            MySqlCommand cmd = new MySqlCommand(cmdString, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id", accountID);

            List<string> favorites = new List<string>();

            using (MySqlDataReader objReader = cmd.ExecuteReader())
            {
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        string item = objReader.GetString(objReader.GetOrdinal("favoriteTicker"));
                        favorites.Add(item);

                    }
                }
            }
            conn.Close();
            return favorites;
        }
    }
}
