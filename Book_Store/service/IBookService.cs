using Book_Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.service
{
   public interface IBookService
    {

        public List<Book> libook();
        public void addbook(Book book);
        public void delete(int Id);
        public Book edit(int id);
        public void update(Book book);
    }
}
