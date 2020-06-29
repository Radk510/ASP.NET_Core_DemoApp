using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Side.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(500)]
        public string LastName { get; set; }

        [Required]
        [StringLength(500)]
        public string PlaceOfBirth { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDath { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        public byte[] AuthorImage { get; set; }
    }
}