using System;
using System.Collections.Generic;

namespace Wardrobe.Infrastructure.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int BrandId { get; set; }
        public string UserId { get; set; }
        public int ArticleTypeId { get; set; }
        public string Size { get; set; }
        public string PrimaryColor { get; set; }
        public string Description { get; set; }

        public virtual ArticleType ArticleType { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<WearEvent> Wearings { get; set; }
        public virtual ICollection<WashEvent> Washings { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Article()
        {
            Wearings = new List<WearEvent>();
            Washings = new List<WashEvent>();
            Tags = new List<Tag>();
        }
    }
}
