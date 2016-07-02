using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Core.Interfaces.Repositories;
using Wardrobe.Core.Models;
using Wardrobe.Services.Enums;

namespace Wardrobe.Infrastructure.Repositories
{
    public class ClosetRepository : IClosetRepository
    {
        IEnumerable<ArticleModel> articles;

        public ClosetRepository()
        {
            //populate "DB" tables

            articles = new List<ArticleModel>()
            {
                new ArticleModel()
                {
                    BrandId = 1,
                    BrandName = "Express",
                    Id = 1,
                    Type = ArticleTypeEnum.Shirt,
                    IsClean = true,
                    Tags = new List<string>() { "Blue", "Small", "Button-Up", "Formal"},
                    Washings = new List<DateTime>() { DateTime.Today.AddDays(-1) },
                    Wearings = new List<DateTime>() { DateTime.Today }
                },
                new ArticleModel()
                {
                    BrandId = 1,
                    BrandName = "Express",
                    Id = 2,
                    Type = ArticleTypeEnum.Pants,
                    IsClean = true,
                    Tags = new List<string>() { "Black", "32x31", "Formal"},
                    Washings = new List<DateTime>() { DateTime.Today.AddDays(-3) },
                    Wearings = new List<DateTime>() { DateTime.Today, DateTime.Today.AddDays(-1) }
                },
                new ArticleModel()
                {
                    BrandId = 2,
                    BrandName = "Banana Republic",
                    Id = 3,
                    Type = ArticleTypeEnum.Shirt,
                    IsClean = false,
                    Tags = new List<string>() { "Blue", "Black", "Small", "Button-Up", "Formal"},
                    Washings = new List<DateTime>() { DateTime.Today.AddDays(-7) },
                    Wearings = new List<DateTime>() { DateTime.Today.AddDays(-1), DateTime.Today.AddDays(-4) }
                }
            };
        }

        public ArticleModel GetArticle(int articleId)
        {
            return articles.FirstOrDefault(article => article.Id == articleId);
        }

        //ToDo: include active bool?
        public IEnumerable<ArticleModel> GetArticles()
        {
            return articles;
        }
    }
}
