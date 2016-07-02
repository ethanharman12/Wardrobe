using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Core.Models;

namespace Wardrobe.Core.Interfaces.Services
{
    public interface IClosetService
    {
        ArticleModel GetArticle(int articleId);

        IEnumerable<ArticleModel> GetArticles();
    }
}
