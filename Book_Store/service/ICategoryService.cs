using Book_Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.service
{
   public interface ICategoryService
    {
        public void addcategory(Category category);
        public List<Category> licategory();
        public void delete(int Id);
        public Category edit(int id);
        public void update(Category category);
    }
}
