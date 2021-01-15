using StonkView.Models;
using System;
using System.Collections.Generic;

namespace StonkView.Inferface
{
    public interface INewsDAL
    {
        NewsModel.NewsArray[] LoadNews();
    }
}