using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wardrobe.API.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string BrandName { get; set; }
        public bool IsClean { get; set; }
    }
}