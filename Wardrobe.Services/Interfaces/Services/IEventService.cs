using System;
using System.Collections.Generic;
using Wardrobe.Core.Models;

namespace Wardrobe.Core.Interfaces.Services
{
    public interface IEventService
    {
        List<DateTime> GetWearings(int articleId, string userId);
        List<ArticleModel> GetWornClothes(DateTime wearDate, string userId);
        void WearArticle(int articleId, DateTime date, string userId);
    }
}
