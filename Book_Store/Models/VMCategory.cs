using Book_Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class VMCategory
    {
        public Category category { get; set; }
        public List<Category> licategory { get; set; }
    }
}
