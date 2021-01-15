using System;
using System.Collections.Generic;
using System.Text;
using StonkView.DataAccess;
using StonkView.Inferface;

namespace StonkView.Factory
{
    public class StockFactory
    {
        public static IStockDAL GetDAL()
        {
            return new StockDAL();
        }
    }
}
