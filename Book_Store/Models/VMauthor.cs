using Book_Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class VMauthor
    {
      public  Author author { set; get; }
        
       public List<Nationality> linationality { set; get; }
        public List<Author> liauthor { set; get; }
    }
}
