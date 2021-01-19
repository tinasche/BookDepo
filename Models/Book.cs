using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookDepo.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }
        
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