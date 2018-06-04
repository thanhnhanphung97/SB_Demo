using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Areas.Admin.Models
{
    public class AccountModel
    {
        private string userName;
        private string password;

        [Required(ErrorMessage = "This is a required field.")]
        public string UserName { get => userName; set => userName = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Password { get => password; set => password = value; }
    }
}