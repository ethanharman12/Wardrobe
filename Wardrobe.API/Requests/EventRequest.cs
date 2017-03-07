using System;

namespace Wardrobe.API.Requests
{
    public class EventRequest
    {
        public int ArticleId { get; set; }
        public DateTime Date { get; set; }
    }
}