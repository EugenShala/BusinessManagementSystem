﻿using System.ComponentModel.DataAnnotations;

namespace BMS.DataAccess.Models.Roles
{
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
}
