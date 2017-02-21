using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Core.Interfaces.Repositories;
using Wardrobe.Core.Models;
using Wardrobe.Infrastructure.Entities;
using Wardrobe.Services.Enums;

namespace Wardrobe.Infrastructure.Repositories
{
    public class ClosetRepository : IClosetRepository
    {
        IEnumerable<ArticleModel> articles;
        private readonly WardrobeContext _context;

        public ClosetRepository(WardrobeContext context)
        {
            //populate "DB" tables
            _context = context;
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
                    Wearings = new List<DateTime>() { DateTime.Today },
                    UserId = "7081805b-79b8-42e6-8be6-af8dc664756c"
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
                    Wearings = new List<DateTime>() { DateTime.Today, DateTime.Today.AddDays(-1) },
                    UserId = "7081805b-79b8-42e6-8be6-af8dc664756c"
                },
                new ArticleModel()
                {
                    BrandId = 1,
                    BrandName = "Express",
                    Id = 5,
                    Type = ArticleTypeEnum.Pants,
                    IsClean = true,
                    Tags = new List<string>() { "Black", "32x31", "Formal"},
                    Washings = new List<DateTime>() { DateTime.Today.AddDays(-3) },
                    Wearings = new List<DateTime>() { DateTime.Today, DateTime.Today.AddDays(-1) },
                    UserId = "someoneelse"
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
                    Wearings = new List<DateTime>() { DateTime.Today.AddDays(-1), DateTime.Today.AddDays(-4) },
                    UserId = "7081805b-79b8-42e6-8be6-af8dc664756c"
                }
            };
        }
        
        public ArticleModel CreateArticle(ArticleModel article)
        {
            var articleEntity = new Article
            {
                ArticleTypeId = (int)article.Type,
                BrandId = article.BrandId,
                Description = article.Description,
                PrimaryColor = article.PrimaryColor,
                PurchaseDate = article.PurchaseDate,
                Size = article.Size,
                UserId = article.UserId                
            };

            _context.Articles.Add(articleEntity);
            _context.SaveChanges();

            return MapArticle(articleEntity);
        }
        
        public ArticleModel GetArticle(int articleId, string userId)
        {
            return MapArticle(_context.Articles.FirstOrDefault(article => article.Id == articleId && article.UserId == userId));
            //return articles.FirstOrDefault(article => article.Id == articleId && article.UserId == userId);
        }

        //ToDo: include active bool?
        public IEnumerable<ArticleModel> GetArticles(string userId)
        {
            return _context.Articles.Where(article => article.UserId == userId).Select(MapArticle);
            //return articles.Where(article => article.UserId == userId).ToList();
        }


        private ArticleModel MapArticle(Article article)
        {
            if (article == null) return null;

            return new ArticleModel
            {
                BrandId = article.BrandId,
                BrandName = article.Brand.Name,
                Description = article.Description,
                Id = article.Id,
                IsClean = article.Washings.Any(),
                PrimaryColor = article.PrimaryColor,
                PurchaseDate = article.PurchaseDate,
                Size = article.Size,
                Tags = article.Tags.Select(tag => tag.TagType.Name),
                Type = (ArticleTypeEnum)article.ArticleTypeId,
                UserId = article.UserId,
                Washings = article.Washings.Select(washing => washing.EventDate),
                Wearings = article.Wearings.Select(wearing => wearing.EventDate)
            };
        }
    }
}
