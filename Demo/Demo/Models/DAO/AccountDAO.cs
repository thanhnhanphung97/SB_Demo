using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Demo.Models.DTO;
namespace Demo.Models.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance { get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; } private set => instance = value; }

        public bool Login(string username,string password)
        {
            string query = "EXEC Sp_Account_Login @UserName , @Password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username , password });

            return result.Rows.Count > 0;
        }
    }
}