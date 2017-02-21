using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Wardrobe.API.MappingServices;
using Wardrobe.API.Requests;
using Wardrobe.API.ViewModels;
using Wardrobe.Core.Interfaces.Services;
using Wardrobe.Core.Models;

namespace Wardrobe.API.Controllers
{
    [Authorize]
    public class ClosetController : ApiController
    {
        private readonly IClosetService _closetService;

        public ClosetController(IClosetService closetService)
        {
            _closetService = closetService;
        }

        [HttpPost]
        public HttpResponseMessage CreateArticle(CreateArticleRequest request)
        {
            //if invalid return Request.CreateResponse("BAD");

            var article = new ArticleModel()
            {
                BrandId = request.BrandId,
                Description = request.Description,
                PrimaryColor = request.PrimaryColor,
                PurchaseDate = request.PurchaseDate,
                Size = request.Size,
                Type = request.ArticleType,
                UserId = User.Identity.GetUserId()
            };

            _closetService.CreateArticle(article);
            return Request.CreateResponse(HttpStatusCode.OK, ClosetMapper.MapArticle(article));
        }

        [HttpGet]
        public ArticleViewModel GetArticle(int id)
        {
            var article = _closetService.GetArticle(id, User.Identity.GetUserId());
            return ClosetMapper.MapArticle(article);
        }

        [HttpGet]
        public IEnumerable<ArticleViewModel> GetAllClothes()
        {
            var articles = _closetService.GetArticles(User.Identity.GetUserId());
            return articles.Select(ClosetMapper.MapArticle);
        }
    }
}
