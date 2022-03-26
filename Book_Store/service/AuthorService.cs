using Book_Store.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.service
{
    public class AuthorService:IAuthorService
    {
        BookContext context;
        public AuthorService(BookContext _context)
        {
            context = _context;
        }
        public void addauthor(Author author)
        {
            context.author.Add(author);
            context.SaveChanges();
        }
        public List<Author> liauthor()
        {
           List<Author> liauthor=context.author.ToList();
            return liauthor;
        }
        public List<Nationality> linationality()
        {
            List<Nationality> linationality = context.nationality.ToList();
            return linationality;
        }
        public Author delete(int Id)
        {
            Author author = context.author.Find(Id);
            context.author.Remove(author);
            context.SaveChanges();
            return author;
        }
        public Author edit(int id)
        {
            Author author = context.author.Find(id);
            return author;
        }
        public void update(Author author)
        {
            context.author.Attach(author);
            context.Entry(author).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
