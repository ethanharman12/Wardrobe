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

        public ArticleModel GetArticle(int articleId)
        {
            return _closetRepository.GetArticle(articleId);
        }

        public IEnumerable<ArticleModel> GetArticles()
        {
            return _closetRepository.GetArticles();
        }
    }
}
