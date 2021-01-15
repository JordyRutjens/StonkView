using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Data;
using StonkView.Models;
using Newtonsoft.Json;
using StonkView.Inferface;

namespace StonkView.DataAccess
{
    public class StockDAL : IStockDAL
    {
        StockModel.StockArray stockArray = new StockModel.StockArray();
        public StockModel.StockArray[] LoadStocks()
        {
            using (var webClient = new WebClient())
            {
                String jsonString = webClient.DownloadString("https://pkgstore.datahub.io/core/s-and-p-500-companies/constituents_json/data/8fd832966a715a70cb9cf3f723498e3b/constituents_json.json");
                return stockArray.FromJson(jsonString);
            }
        }

        public void LoadStockDetail(string tickername)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://www.alphavantage.co/query?function=OVERVIEW&symbol=" + tickername + "&apikey=&apikey=QEEUW4RQQ3JJFSF2");
            dynamic dobj = JsonConvert.DeserializeObject<dynamic>(json);

            #region DeclareData
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
            #endregion

            #region StoreData
            StockData.ticker = ticker;
            StockData.name = name;
            StockData.description = description;
            StockData.industry = industry;
            StockData.shortratio = shortratio;
            StockData.eps = eps;
            StockData.high52 = high52;
            StockData.low52 = low52;
            StockData.dividentDate = dividentdate;
            StockData.dividentYield = dividentyield;
            StockData.latestQuarter = latestQuarter;
            StockData.marketCapitalization = marketcapitalization;
            StockData.fulltimeemployees = fulltimeemployees;
            StockData.profitmargin = profitmargin;
            StockData.quarterlyEarningsGrowthYOY = quarterlyearningsgrowthYOY;
            StockData.movingAverage50 = movingaverage50;
            #endregion  
        }
    }
}
