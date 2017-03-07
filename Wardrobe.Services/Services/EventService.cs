using System;
using System.Collections.Generic;
using System.Linq;
using Wardrobe.Core.Interfaces.Repositories;
using Wardrobe.Core.Interfaces.Services;

namespace Wardrobe.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IClosetRepository _closetRepository;

        public EventService(IClosetRepository closetRepository)
        {
            _closetRepository = closetRepository;
        }

        public List<DateTime> GetWearings(int articleId, string userId)
        {
            var article = _closetRepository.GetArticle(articleId, userId);

            if (article == null)
            {
                //should differentiate between no article and not authorized
                throw new Exception("No Article with ID " + articleId + " for this user.");
            }

            return article.Wearings.ToList();
        }

        public List<Models.ArticleModel> GetWornClothes(DateTime wearDate, string userId)
        {
            var articles = _closetRepository.GetWornArticles(wearDate, userId);

            return articles.ToList();
        }

        public void WearArticle(int articleId, DateTime date, string userId)
        {
            var article = _closetRepository.GetArticle(articleId, userId);

            if (article == null)
            {
                //should differentiate between no article and not authorized
                throw new Exception("No Article with ID " + articleId + " for this user.");
            }

            _closetRepository.Wear(articleId, date);
        }
    }
}
