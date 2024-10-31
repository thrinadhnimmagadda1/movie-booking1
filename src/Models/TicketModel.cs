using System.ComponentModel.DataAnnotations;

namespace MovieReviewApi.Models {
    public class Ticket
    {
        public int Id { get; set; } // Unique identifier

        [Required]
        public int MovieId { get; set; } // Foreign key to Movie

        [Required]
        public int SeatNumber { get; set; } // Seat number for the ticket

        public decimal Price { get; set; } // Price of the ticket
    }
}