using Book_Store.helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.data
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Yearvalidation]
        public string Year { get; set; }

        public float Price { get; set; }

        public int Stock { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        [ForeignKey("category")]
        public int category_id { get; set; }
        [ForeignKey("author")]
        public int author_id { get; set; }

        public Category category { get; set; }
        public Author author { get; set; }


    }
}
