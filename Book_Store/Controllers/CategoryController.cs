using Book_Store.data;
using Book_Store.Models;
using Book_Store.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    [Authorize]
    public class CategoryController : Controller
        
    {
        ICategoryService categoryservice;
        public CategoryController(ICategoryService _categoryservice)
        {
            categoryservice = _categoryservice;
        }
        public IActionResult Index()
        {
            VMCategory vm = new VMCategory();
            vm.licategory = categoryservice.licategory();
            vm.category = new Category();
            return View("Index",vm);
        }
        public IActionResult addcategory(VMCategory model)
        {
            categoryservice.addcategory(model.category);
            VMCategory vm = new VMCategory();
            vm.licategory = categoryservice.licategory();
            return View("Index", vm);

        }
        public IActionResult delete(int Id)
        {
            categoryservice.delete(Id);
            VMCategory vm = new VMCategory();
            vm.licategory = categoryservice.licategory();
            return View("Index", vm);
        }


        public IActionResult edit(int id)
        {
            VMCategory vm = new VMCategory();
            vm.licategory = categoryservice.licategory();
            vm.category = categoryservice.edit(id);
            return Json(vm.category);
        }


        public IActionResult updatecategory(Category category)
        {
            categoryservice.update(category);
            VMCategory vm = new VMCategory();
            vm.licategory = categoryservice.licategory();
            
            return View("Index",vm);
        }

    }
}
