using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StonkView.Logic;
using StonkView.Models;
using StonkView.Factory;
using System.Web;


namespace StonkView.Controllers
{
    public class StockController : Controller
    {
        Stock stock = new Stock();
        Favorite favorite = new Favorite();

        public IActionResult Stocks()
        {
            ViewData["StockList"] = stock.LoadStocks();
            return View();
        }
        public IActionResult LoadStock(string ticker)
        {
            stock.LoadStockDetail(ticker);
            return View("StockDetails");
        }

        public IActionResult StockDetails(object sender, EventArgs e)
        {
            return View();
        }
        public IActionResult AddFavorite(string ticker)
        {
            favorite.AddFavoriteToAccount(ticker, UserModel.accountID);
            ViewData["StockList"] = stock.LoadStocks();
            return View("Stocks");
        }
        public IActionResult AddTicker()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchStock(SearchModel searchModel)
        {
            stock.LoadStockDetail(searchModel.searchTicker);
            if (StockData.ticker == null)
            {
                SearchModel.errorTextSearch = "Couldn't load stock, please enter a valid ticker.";
                return View("Search");
            }
            return View("StockDetails");
        }
    }
}