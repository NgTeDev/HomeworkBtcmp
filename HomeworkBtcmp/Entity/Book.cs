using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkBtcmp.Entity
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public List<Genre> Genres { get; set; }
        
    }
}
