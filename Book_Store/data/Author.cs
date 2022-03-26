using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.data
{
    [Table("Author")]
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
      //  [RegularExpression(@"^07[789]-\d{7}$")]
        public string Phone { get; set; }
      
        public string Path { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        [ForeignKey("nationality")]
        public int nationality_id { get; set; }

        public Nationality nationality { get; set; }
        public List<Book> libook { set; get; }
    }
}
