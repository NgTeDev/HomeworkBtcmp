using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkBtcmp.Entity
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
