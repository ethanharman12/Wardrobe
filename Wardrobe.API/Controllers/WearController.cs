using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wardrobe.API.MappingServices;
using Wardrobe.API.Requests;
using Wardrobe.API.ViewModels;
using Wardrobe.Core.Interfaces.Services;

namespace Wardrobe.API.Controllers
{
    [Authorize]
    public class WearController : ApiController
    {
        private readonly IEventService _eventService;

        public WearController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public void Wear(EventRequest request)
        {
            _eventService.WearArticle(request.ArticleId, request.Date, User.Identity.GetUserId());
        }

        [HttpGet]
        public List<DateTime> Get(int id)
        {
            var events = _eventService.GetWearings(id, User.Identity.GetUserId());
            return events;
        }

        [HttpGet]
        public List<ArticleViewModel> GetDate(DateTime wearDate)
        {
            var articles = _eventService.GetWornClothes(wearDate, User.Identity.GetUserId());
            return articles.Select(ClosetMapper.MapArticle).ToList();
        }
    }
}
