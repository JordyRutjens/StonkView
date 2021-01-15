using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StonkView.Logic;
using StonkView.Models;
using StonkView.DataAccess;
using System.Web;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StonkView.Controllers
{
    public class StockController : Controller
    {
        Stock stock = new Stock();
        Favorite favorite = new Favorite();
        private void GetConnectionString()
        {
            var builder = new
            ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",
            optional: true, reloadOnChange: true);

            string _connectionString = builder.Build().GetSection("ConnectionStrings").GetSection("DatabaseConnection").Value;
            favorite.SetConnection(_connectionString);
        }

        public IActionResult Stocks()
        {
            GetConnectionString();
            ViewData["StockList"] = stock.LoadStocks();
            return View();
        }
        public IActionResult LoadStock(string ticker)
        {
            stock.LoadStockDetail(ticker);
            return View("StockDetails");
        }

        public IActionResult StockDetails()
        {
            return View();
        }
        public IActionResult AddFavorite(string ticker)
        {
            if (UserModel.accountID > 0)
            {
                GetConnectionString();
                favorite.AddFavoriteToAccount(ticker, UserModel.accountID);
                ViewData["StockList"] = stock.LoadStocks();
                return View("Stocks");
            }
            else
            {
                return RedirectToAction("AccountManagement", "Account");
            }
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

        public IActionResult Favorite()
        {
            if (UserModel.accountID > 0)
            {
                GetConnectionString();
                List<string> favoriteList = favorite.GetFavoriteFromAccount(UserModel.accountID);
                ViewData["FavoriteListAccount"] = favoriteList;
                return View();
            }
            else
            {
                return RedirectToAction("AccountManagement", "Account");
            }
        }
    }
}