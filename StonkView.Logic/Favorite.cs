using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StonkView.DataAccess;

namespace StonkView.Logic
{
    public class Favorite
    {
        FavoriteDAL favorite = new FavoriteDAL();
        public void AddFavoriteToAccount(string ticker, int id)
        {
            favorite.addFavoriteStockToAccount(ticker, id);
        }
    }
}
