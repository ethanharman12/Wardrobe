using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Services.Enums;

namespace Wardrobe.Core.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public ArticleTypeEnum Type { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool IsClean { get; set; }
        public string Size { get; set; }
        public string PrimaryColor { get; set; }
        public string Description { get; set; }

        public DateTime PurchaseDate { get; set; }

        public IEnumerable<DateTime> Wearings { get; set; }
        public IEnumerable<DateTime> Washings { get; set; }

        public string UserId { get; set; }
    }
}
