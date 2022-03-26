using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class SignInModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public Boolean rememberMe { get; set; }
    }
}
