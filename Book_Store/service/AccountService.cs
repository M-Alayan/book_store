using Book_Store.data;
using Book_Store.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.service
{
    public class AccountService:IAccountService
    {
        BookContext context;
        UserManager<User> usermanager;
        SignInManager<User> signinmanager;
        RoleManager<IdentityRole> rolemanager;
        public AccountService(BookContext _context, UserManager<User> _usermanager, SignInManager<User> _signinmanager, RoleManager<IdentityRole> _rolemanager)
        {
            context = _context;
            usermanager = _usermanager;
            signinmanager = _signinmanager;
            rolemanager = _rolemanager;
          
        }

        public async Task<IdentityResult> signup(SignUpModel model)
        {
            User user = new User();
            user.Name = model.Name;
            user.UserName = model.Username;
            user.Email = model.Email;
            var result = await usermanager.CreateAsync(user, model.Password);
            return result;

        }

        public async Task<SignInResult> Login(SignInModel model)
        {
            var result = await signinmanager.PasswordSignInAsync(model.Name, model.Password, model.rememberMe, false);
            return result;
        }
        public async Task<IdentityResult> addrole(RoleModel role)
        {
            IdentityRole r = new IdentityRole();
            r.Name = role.Name;
            var result = await rolemanager.CreateAsync(r);
            return result;
        }
        public List<IdentityRole> getrole()
        {
            List<IdentityRole> role = rolemanager.Roles.ToList();
            return role;
        }
        public async Task signout()
        {
            await signinmanager.SignOutAsync();
        }

    }
}
