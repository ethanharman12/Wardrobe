using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Core.Models;
using Wardrobe.Services.Enums;

namespace Wardrobe.Core.Interfaces.Repositories
{
    public interface IClosetRepository
    {
        ArticleModel CreateArticle(ArticleModel article);

        ArticleModel GetArticle(int articleId, string userId);

        IEnumerable<ArticleModel> GetArticles(string userId);
    }
}
