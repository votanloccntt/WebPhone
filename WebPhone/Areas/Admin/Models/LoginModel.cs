using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPhone.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        public bool Rememberme { get; set; }
    }
}