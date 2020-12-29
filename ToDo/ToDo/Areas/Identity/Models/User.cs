using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Areas.Identity.Models
{
    public class User : IdentityUser<int>
    {
        public override int Id { get; set; }
    }
}
