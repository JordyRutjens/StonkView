using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Data;
using StonkView.Models;
using Newtonsoft.Json;
using StonkView.Factory;
using StonkView.Inferface;

namespace StonkView.Logic
{
    public class Stock : IStockDAL
    {
        private IStockDAL stock = StockFactory.GetDAL();
        public StockModel.StockArray[] LoadStocks()
        {
            return stock.LoadStocks();
        }

        public void LoadStockDetail(string tickername)
        {
            stock.LoadStockDetail(tickername);
        }
    }
}
