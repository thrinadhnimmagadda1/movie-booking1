/*
 * Model class for Movie. Stores the properties of a movie.
 * 
 * CSCE547 - Windows/C# Programming
 * @author Scott Do (Reshlynt)
 */
namespace MovieReviewApi.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string ShowTime { get; set; }
    }
}
