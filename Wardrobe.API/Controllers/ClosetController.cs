using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Wardrobe.API.MappingServices;
using Wardrobe.API.ViewModels;
using Wardrobe.Core.Interfaces.Services;

namespace Wardrobe.API.Controllers
{
    public class ClosetController : ApiController
    {
        private readonly IClosetService _closetService;

        public ClosetController(IClosetService closetService)
        {
            _closetService = closetService;
        }

        [HttpGet]
        public IEnumerable<ArticleViewModel> GetAllClothes()
        {
            var articles = _closetService.GetArticles();
            return articles.Select(ClosetMapper.MapArticle);
        }

        [HttpGet, Route("{articleId}")]
        public ArticleViewModel GetArticle(int id)
        {
            var article = _closetService.GetArticle(id);
            return ClosetMapper.MapArticle(article);
        }
    }
}
