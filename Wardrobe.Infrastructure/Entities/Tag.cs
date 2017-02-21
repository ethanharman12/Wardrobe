using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Infrastructure.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int TagTypeId { get; set; }
        public string Description { get; set; }

        public virtual TagType TagType { get; set; }
        public virtual Article Article { get; set; }
    }
}
