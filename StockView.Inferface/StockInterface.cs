using StonkView.Models;
using System;
using System.Collections.Generic;

namespace StonkView.Inferface
{
    public interface IStockDAL
    {
        StockModel.StockArray[] LoadStocks();
        void LoadStockDetail(string tickername);
    }
}