using Book_Store.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.service
{
    public class CategoryService : ICategoryService
    {
        BookContext context;
        public CategoryService(BookContext _context)
        {
            context = _context;
        }
        public void addcategory(Category category)
        {
            context.category.Add(category);
            context.SaveChanges();
        }
        public List<Category> licategory()
        {
            List<Category> licategory = context.category.ToList();
            return licategory;
        }
        public void delete(int Id)
        {
            Category cat = context.category.Find(Id);
            context.category.Remove(cat);
            context.SaveChanges();
        }
        public Category edit(int id)
        {
            Category category = context.category.Find(id);
            return category;
        }
        public void update(Category category)
        {
            context.category.Attach(category);
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
