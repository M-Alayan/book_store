using Book_Store.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.service
{
  public  interface IAccountService
    {
        Task<IdentityResult> signup(SignUpModel model);
        Task<SignInResult> Login(SignInModel model);
        public List<IdentityRole> getrole();
      Task<IdentityResult> addrole(RoleModel role);
        Task signout();
    }
}
