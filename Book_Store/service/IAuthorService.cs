using Book_Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.service
{
  public  interface IAuthorService
    {
        public void addauthor(Author author);
        public List<Author> liauthor();
        public List<Nationality> linationality();
        public Author delete(int Id);
        public Author edit(int id);
        public void update(Author author);
    }
}
