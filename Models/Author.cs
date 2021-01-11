using System;
using System.ComponentModel.DataAnnotations;

namespace BookDepo.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        
        public int BooksPublished { get; set; }
    }
}