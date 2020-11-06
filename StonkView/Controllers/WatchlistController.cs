using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace StonkView.Controllers
{
    public class WatchlistController
    {
        public static void LoadStocks()
        {
            //Data.Stock stock = new Data.Stock();

            WebClient client = new WebClient();
            string json = client.DownloadString("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=TSLA&apikey=QEEUW4RQQ3JJFSF2");

            dynamic dobj = JsonConvert.DeserializeObject<dynamic>(json);
            
            string date = dobj["Meta Data"]["3. Last Refreshed"];
            

            string ticker = dobj["Meta Data"]["2. Symbol"];

            string open = dobj["Time Series (Daily)"][date]["1. open"];
            string high = dobj["Time Series (Daily)"][date]["2. high"];
            string low = dobj["Time Series (Daily)"][date]["3. low"];
            string close = dobj["Time Series (Daily)"][date]["4. close"];
            string volume = dobj["Time Series (Daily)"][date]["5. volume"];

            //int _open = Int32.Parse(open);
            //open = _open.ToString();

            //stock.ticker = ticker;
            //stock.open = open; 
            //stock.close = close;
            //stock.low = low;
            //stock.high = high;
            //stock.volume = volume;

            Data.Stock.ticker = ticker;
            Data.Stock.open = open;
            Data.Stock.close = close;
            Data.Stock.low = low;
            Data.Stock.high = high;
            Data.Stock.volume = volume;
        }
    }
}
