using System.ComponentModel.DataAnnotations;

namespace BookDepo.Dtos
{
    public class AuthorAddDto
    {
        
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        
        public int BooksPublished { get; set; }
    }
}