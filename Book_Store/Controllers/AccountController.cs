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
    public class AccountController : Controller
    {
        IAccountService accountservice;
        public AccountController(IAccountService _accountservice)
        {
            accountservice=_accountservice;
        }
        public IActionResult Index()
        {
            VMuser vm = new VMuser();
            vm.lirole= accountservice.getrole();
            return View("SignUp",vm);
        }
        public async Task<IActionResult> signup(SignUpModel signUp)
        {
            VMuser vm = new VMuser();
            vm.lirole = accountservice.getrole();
            var result=await accountservice.signup(signUp);
            return View("SignUp",vm);
        }
        public IActionResult signin()
        {
            return View("SignIn");
        }
        public async Task<IActionResult> login(SignInModel signin)
        {
            var result = await accountservice.Login(signin);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["msg"] = "User name or password is incorrect";
                return View("SignIn");
            }
        }
        [Authorize]
        public IActionResult role()
        {
            return View("AddRole");
        }
        [Authorize(Roles="ADMIN")]
        public async Task<IActionResult> addrole(RoleModel role)
        {
            var result = await accountservice.addrole(role);
            return View("AddRole");
        }
        public IActionResult accessdenied()
        {
            return View("View");
        }
        public async Task<IActionResult> logout()
        {
            await accountservice.signout();
            return View("SignIn");
        }

    }
}
