using Book_Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class VMbook
    {
     public Book book { set; get; }
        public List<Book> libook { set; get; }
      public List<Author> liauthor { set; get; }
       public List<Category> licategory { set; get; }
    }
}
