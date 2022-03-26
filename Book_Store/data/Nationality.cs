using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.data
{
    [Table("Nationality")]
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Author> liauthor { set; get; }
    }
}
