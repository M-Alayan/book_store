using Book_Store.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.service
{
    public class BookService:IBookService
    {
        BookContext context;
        public BookService(BookContext _context)
        {
            context = _context;
        }
        public void addbook(Book book)
        {
            context.book.Add(book);
            context.SaveChanges();
        }
        public List<Book> libook()
        {
            List<Book> libook = context.book.ToList();
            return libook;
        }
        public void delete(int Id)
        {
            Book book = context.book.Find(Id);
            context.book.Remove(book);
            context.SaveChanges();
        }

        public Book edit(int id)
        {
            Book book = context.book.Find(id);
            return book;
        }
        public void update(Book book)
        {
            context.book.Attach(book);
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
