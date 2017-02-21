using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wardrobe.Services.Enums;

namespace Wardrobe.API.Requests
{
    public class CreateArticleRequest
    {
        public DateTime PurchaseDate { get; set; }
        public ArticleTypeEnum ArticleType { get; set; }

        public int BrandId { get; set; }
        public string Description { get; set; }
        public string PrimaryColor { get; set; }
        public string Size { get; set; }
    }
}