using System.ComponentModel.DataAnnotations;

namespace Mission6_Assignment.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        public string Director { get; set; }

        public string Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        public string? Notes { get; set; }
    }
}