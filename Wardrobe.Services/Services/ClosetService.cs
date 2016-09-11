using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ArticleModel GetArticle(int articleId, string userId)
        {
            return _closetRepository.GetArticle(articleId, userId);
        }

        public IEnumerable<ArticleModel> GetArticles(string userId)
        {
            return _closetRepository.GetArticles(userId);
        }
    }
}
