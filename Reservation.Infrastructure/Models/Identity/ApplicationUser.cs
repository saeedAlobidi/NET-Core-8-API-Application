using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Infrastructure.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImgUrl { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
