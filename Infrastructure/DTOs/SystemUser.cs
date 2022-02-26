using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs
{
   public class SystemUser : IdentityUser
    {
        public string name { get; set; }
        public string age { get; set; }

        public string roleName{ get; set; }

    }
}
