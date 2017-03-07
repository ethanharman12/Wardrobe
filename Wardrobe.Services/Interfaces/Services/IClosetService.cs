using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Core.Models;
using Wardrobe.Core.Enums;

namespace Wardrobe.Core.Interfaces.Services
{
    public interface IClosetService
    {
        ArticleModel CreateArticle(ArticleModel article);

        ArticleModel GetArticle(int articleId, string userId);

        List<ArticleModel> GetArticles(string userId);
    }
}
