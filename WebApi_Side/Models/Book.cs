using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi_Side.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Genre { get; set; }

        [Required]
        public DateTime DateOfRelize { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public string Description { get; set; }

        public byte[] BookImage { get; set; }
    }
}
