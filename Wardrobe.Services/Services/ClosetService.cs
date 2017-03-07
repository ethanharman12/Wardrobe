using System.Collections.Generic;
using Wardrobe.Core.Interfaces.Repositories;
using Wardrobe.Core.Interfaces.Services;
using Wardrobe.Core.Models;

namespace Wardrobe.Core.Services
{
    public class ClosetService : IClosetService
    {
        private readonly IClosetRepository _closetRepository;

        public ClosetService(IClosetRepository closetRepository)
        {
            _closetRepository = closetRepository;
        }

        public ArticleModel CreateArticle(ArticleModel article)
        {
            return _closetRepository.CreateArticle(article);
        }

        public ArticleModel GetArticle(int articleId, string userId)
        {
            return _closetRepository.GetArticle(articleId, userId);
        }

        public List<ArticleModel> GetArticles(string userId)
        {
            return _closetRepository.GetArticles(userId);
        }
    }
}
