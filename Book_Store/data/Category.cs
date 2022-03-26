using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.data
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CategoryCode { get; set; }

        public List<Book> libook { set; get; }
    }
}
