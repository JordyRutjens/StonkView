using StonkView.Models;
using System;
using System.Collections.Generic;

namespace StonkView.Inferface
{
    public interface IFavorite
    {

    }

    public interface IFavoriteDAL
    {
        void addFavoriteStockToAccount(string ticker, int id);
        List<string> getFavoriteStockFromAccount(int accountID);
        void SetConnection(string connectionString);
    }
}
