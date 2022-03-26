using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class VMuser
    {
        public SignUpModel signup { set; get; }
        public List<IdentityRole> lirole { set; get; }
    }
}
