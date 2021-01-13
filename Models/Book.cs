using System;
using System.ComponentModel.DataAnnotations;

namespace BookDepo.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public Author Author { get; set; }  // TODO: Check on Stored Procedures for adding author.id in the database.

        [Required]
        public string Genre { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }
    
        public int PublishedYear { get; set; }

        [MaxLength(100)]
        public string Publisher { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}