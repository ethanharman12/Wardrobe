using System;
using System.Collections.Generic;
using Wardrobe.Core.Models;

namespace Wardrobe.Core.Interfaces.Repositories
{
    public interface IClosetRepository
    {
        ArticleModel CreateArticle(ArticleModel article);

        ArticleModel GetArticle(int articleId, string userId);

        List<ArticleModel> GetArticles(string userId);

        List<ArticleModel> GetWornArticles(DateTime date, string userId);

        void Wear(int articleId, DateTime date);
    }
}
