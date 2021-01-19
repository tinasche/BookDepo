using System;
using System.ComponentModel.DataAnnotations;

namespace BookDepo.Models
{
    public class Patron
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
 
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}