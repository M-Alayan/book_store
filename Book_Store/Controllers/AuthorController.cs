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
    public class AuthorController : Controller
    {
        IAuthorService authorservice;
        IConfiguration config;
      
        public AuthorController(IAuthorService _authorservice, IConfiguration _config)
        {
            authorservice = _authorservice;
            config = _config;
        }
        public IActionResult Index()
        {
            VMauthor vm = new VMauthor();
            vm.linationality = authorservice.linationality();
            vm.liauthor = authorservice.liauthor();
            return View(vm);
        }
        public IActionResult addauthor(VMauthor model)
        {
            if (model.author.Image != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), config["Filepath"], model.author.Image.FileName);

                model.author.Image.CopyTo(new FileStream(path, FileMode.Create));
                model.author.Path = "http://localhost/bookstore/img/" + model.author.Image.FileName;
            }

            authorservice.addauthor(model.author);
            VMauthor vm = new VMauthor();
            vm.linationality = authorservice.linationality();
            vm.liauthor = authorservice.liauthor();
            return View("Index",vm);
        }
        public IActionResult delete(int Id)
        {
             var author = authorservice.delete(Id);

         
            VMauthor vm = new VMauthor();
            vm.linationality = authorservice.linationality();
            vm.liauthor = authorservice.liauthor();
            return View("Index", vm);
        }

        public IActionResult edit(int id)
        {
            VMauthor vm = new VMauthor();
            vm.liauthor= authorservice.liauthor();
            vm.linationality = authorservice.linationality();
            vm.author = authorservice.edit(id);
            return Json(vm);
        }


        public IActionResult updateauthor(Author author)
        {
            authorservice.update(author);
            VMauthor vm = new VMauthor();
            vm.liauthor = authorservice.liauthor();
            vm.linationality = authorservice.linationality();

            return View("Index", vm);
        }



    }
}
