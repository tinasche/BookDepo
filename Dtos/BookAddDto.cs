using System;
using System.ComponentModel.DataAnnotations;
using BookDepo.Models;

namespace BookDepo.Dtos
{
    public class BookAddDto
    {

        [Required]
        public Author Author { get; set; }

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