using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wardrobe.API.ViewModels;
using Wardrobe.Core.Models;

namespace Wardrobe.API.MappingServices
{
    public static class ClosetMapper
    {
        public static ArticleViewModel MapArticle(ArticleModel model)
        {
            if (model == null) return null;

            return new ArticleViewModel()
            {
                BrandName = model.BrandName,
                Id = model.Id,
                IsClean = model.IsClean,
                Tags = model.Tags,
                Type = model.Type.ToString()
            };
        }
    }
}