using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyWeb.Models
{
    public class AppUsers:IdentityUser
    {
        public int MyProperty { get; set; }
    }
}