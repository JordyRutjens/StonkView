using System;
using System.Collections.Generic;
using System.Text;
using StonkView.DataAccess;
using StonkView.Inferface;

namespace StonkView.Factory
{
    public class NewsFactory
    {
        public static INewsDAL GetDAL()
        {
            return new NewsDAL();
        }
    }
}
