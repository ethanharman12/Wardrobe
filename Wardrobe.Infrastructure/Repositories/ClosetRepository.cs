using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Wardrobe.Core.Interfaces.Repositories;
using Wardrobe.Core.Models;
using Wardrobe.Infrastructure.Entities;
using Wardrobe.Core.Enums;

namespace Wardrobe.Infrastructure.Repositories
{
    public class ClosetRepository : IClosetRepository
    {
        private readonly WardrobeContext _context;

        public ClosetRepository(WardrobeContext context)
        {
            _context = context;            
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
            return MapArticle(_context.Articles//.Include(art => art.Wearings)
                                               //.Include(art => art.Washings)
                                               .FirstOrDefault(article => article.Id == articleId && article.UserId == userId));
        }

        //ToDo: include active bool?
        public List<ArticleModel> GetArticles(string userId)
        {
            return _context.Articles.Where(article => article.UserId == userId).Select(MapArticle).ToList();
        }

        public List<ArticleModel> GetWornArticles(DateTime date, string userId)
        {
            var day = date.Date;
            var dayPlus = date.Date.AddDays(1);
            var articles = _context.Articles.Where(article => article.UserId == userId
                                                           && article.Wearings.Any(wear => wear.EventDate >= day 
                                                                                        && wear.EventDate < dayPlus)).ToList();

            return articles.Select(MapArticle).ToList();
        }

        public void Wear(int articleId, DateTime date)
        {
            var wearEvent = new WearEvent 
            { 
                ArticleId = articleId,
                EventDate = date
            };

            _context.WearEvents.Add(wearEvent);
            _context.SaveChanges();
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
