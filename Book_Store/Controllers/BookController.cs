using Book_Store.data;
using Book_Store.Models;
using Book_Store.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        IConfiguration config;
        IBookService bookservice;
        IAuthorService authorservice;
        ICategoryService categoryservice;
        public BookController(IConfiguration _config, IBookService _bookservice, IAuthorService _authorservice, ICategoryService _categoryservice)
        {
            config = _config;
            bookservice = _bookservice;
            authorservice = _authorservice;
            categoryservice = _categoryservice;
        }
        public IActionResult Index()
        {
            VMbook vm = new VMbook();
            vm.liauthor = authorservice.liauthor();
            vm.licategory = categoryservice.licategory();
            vm.libook = bookservice.libook();
            return View(vm);
        }
        public IActionResult addbook(VMbook model)
        {
            if (model.book.Image != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), config["Filepath"], model.book.Image.FileName);
                model.book.Image.CopyTo(new FileStream(path, FileMode.Create));
                model.book.Path = "http://localhost/bookstore/img/" + model.book.Image.FileName;
            }
           // if (ModelState.IsValid == true) { }
                bookservice.addbook(model.book);
                 
            VMbook vm = new VMbook();
            vm.liauthor = authorservice.liauthor();
            vm.licategory = categoryservice.licategory();
            vm.libook = bookservice.libook();
            return View("Index",vm);
        }

        public IActionResult delete(int Id) {
            bookservice.delete(Id);
            VMbook vm = new VMbook();
        vm.liauthor = authorservice.liauthor();
            vm.licategory = categoryservice.licategory();
            vm.libook = bookservice.libook();
            return View("Index", vm);
    }
        public IActionResult edit(int id)
        {
            VMbook vm = new VMbook();
            vm.liauthor = authorservice.liauthor();
            vm.libook = bookservice.libook();
            vm.licategory = categoryservice.licategory();
            vm.book = bookservice.edit(id);
            return Json(vm.book);
        }


        public IActionResult updatebook(Book book)
        {
            bookservice.update(book);
            VMbook vm = new VMbook();
            vm.liauthor = authorservice.liauthor();
            vm.libook = bookservice.libook();
            vm.licategory = categoryservice.licategory();

            return View("Index", vm);
        }
    }
}
