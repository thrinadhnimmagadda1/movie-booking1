using System.Collections.Generic;

namespace MovieReviewApi.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public decimal TotalAmount { get; set; }
    }
}
