using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Core.Models;

namespace Wardrobe.Core.Interfaces.Repositories
{
    public interface IClosetRepository
    {
        ArticleModel GetArticle(int articleId);

        IEnumerable<ArticleModel> GetArticles();
    }
}
