using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StonkView.Models;
using System.Data;

namespace StonkView.Controllers
{
    public class LoadController : Controller
    {
        public static string tickerName;
        public static void LoadStocks()
        {
            tickerName = "TSLA";
            //Data.Stock stock = new Data.Stock();           
            WebClient client = new WebClient();
            string json = client.DownloadString("https://www.alphavantage.co/query?function=OVERVIEW&symbol=" + tickerName + "&apikey=&apikey=QEEUW4RQQ3JJFSF2");
            dynamic dobj = JsonConvert.DeserializeObject<dynamic>(json);

            string ticker = dobj["Symbol"];
            string name = dobj["Name"];
            string description = dobj["Description"];
            string industry = dobj["Industry"];
            string shortratio = dobj["ShortRatio"];
            string high52 = dobj["52WeekHigh"];
            string low52 = dobj["52WeekLow"];
            string eps = dobj["EPS"];
            string dividentdate = dobj["DividendDate"];
            string dividentyield = dobj["DividendYield"];
            string marketcapitalization = dobj["MarketCapitalization"];
            string fulltimeemployees = dobj["FullTimeEmployees"];
            string profitmargin = dobj["ProfitMargin"];
            string quarterlyearningsgrowthYOY = dobj["QuarterlyEarningsGrowthYOY"];
            string movingaverage50 = dobj["50DayMovingAverage"];
            string latestQuarter = dobj["LatestQuarter"];


            Data.Stock.ticker = ticker;
            Data.Stock.name = name;
            Data.Stock.description = description;
            Data.Stock.industry = industry;
            Data.Stock.shortratio = shortratio;
            Data.Stock.eps = eps;
            Data.Stock.high52 = high52;
            Data.Stock.low52 = low52;
            Data.Stock.dividentDate = dividentdate;
            Data.Stock.dividentYield = dividentyield;
            Data.Stock.latestQuarter = latestQuarter;
            Data.Stock.marketCapitalization = marketcapitalization;
            Data.Stock.fulltimeemployees = fulltimeemployees;
            Data.Stock.profitmargin = profitmargin;
            Data.Stock.quarterlyEarningsGrowthYOY = quarterlyearningsgrowthYOY;
            Data.Stock.movingAverage50 = movingaverage50;

        }
    }
}
