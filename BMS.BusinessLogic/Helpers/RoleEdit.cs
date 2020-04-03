using System;
using System.Collections.Generic;
using System.Text;
using BMS.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace BMS.BusinessLogic.Helpers
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public List<IdentityUser> Members { get; set; }
        public List<IdentityUser> NonMembers { get; set; }
    }
}
