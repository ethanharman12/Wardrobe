using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Infrastructure.Entities
{
    public class WearEvent
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public DateTime EventDate { get; set; }
        public string Notes { get; set; }

        public virtual Article Article { get; set; }
    }
}
