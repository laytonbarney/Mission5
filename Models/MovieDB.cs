using System;
using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class MovieDB
    {
        [Key]//This allows us to autoincrement when a new record is added
        [Required]//This forces the user to fill in this field
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2050, ErrorMessage = "Must be a valid year")]
        public int Year { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent { get; set; }

        [StringLength(25, ErrorMessage ="Notes cannot be longer than 25 characters")]
        public string Notes { get; set; }

        //Build Foreign Key Relationship

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
