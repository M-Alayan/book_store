using Book_Store.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.data
{

    public class BookContext:IdentityDbContext<User>
    {
        IConfiguration config;
        public BookContext(IConfiguration _config)
        {
            config = _config;
        }
      public  DbSet<Author> author { set; get; }
       public DbSet<Book> book { set; get; }
       public DbSet<Category> category { set; get; }
       public DbSet<Nationality> nationality { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("Book"));
            base.OnConfiguring(optionsBuilder);
        }

    }
}
