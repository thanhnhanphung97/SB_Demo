using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Demo.Models.DTO
{
    public class AccountDTO
    {
        public AccountDTO(string username,string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public AccountDTO(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.Password = row["Password"].ToString();
        }


        private string userName;
        private string password;

        [Required(ErrorMessage = "This is a required field.")]
        public string UserName { get => userName; set => userName = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Password { get => password; set => password = value; }

        

    }
}