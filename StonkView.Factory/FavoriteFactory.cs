using System;
using System.Collections.Generic;
using System.Text;
using StonkView.DataAccess;
using StonkView.Inferface;

namespace StonkView.Factory
{
    public class FavoriteFactory
    {
        public static IFavoriteDAL GetDAL()
        {
            return new FavoriteDAL();
        }
    }
}
