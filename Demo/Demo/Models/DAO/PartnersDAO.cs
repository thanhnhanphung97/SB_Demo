using Demo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Demo.Models.DAO
{
    public class PartnersDAO
    {
        private static PartnersDAO instance;

        public static PartnersDAO Instance { get { if (instance == null) instance = new PartnersDAO(); return PartnersDAO.instance; } private set => instance = value; }

        private PartnersDAO() { }

        public List<PartnersDTO> GetListPartners()
        {
            List<PartnersDTO> list = new List<PartnersDTO>();

            string query = "USP_GetAll_Partners";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                PartnersDTO intro = new PartnersDTO(item);
                list.Add(intro);
            }

            return list;
        }

        public bool InsertPartners(string name, string img, string describe, string link)
        {
            string query = "USP_Add_Partners @name , @img , @describe , @background";
            int result = DataProvider.Instance.ExecuteNonQuery(query,new object[] { name , img , describe , link });
            return result > 0;
        }

        public bool EditPartners(int id, string name, string img, string describe, string link)
        {
            string query = "USP_Edit_Partners @id , @name , @img , @describe , @background";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, img, describe, link });
            return result > 0;
        }

        public PartnersDTO GetPartners(int id)
        {
            string query = "USP_Get_Partners @id";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { id });

            foreach (DataRow item in data.Rows)
            {
                return new PartnersDTO(item);
            }
            return null;
        }

        public bool DeletePartners(int id)
        {
            string query = "USP_Delete_Partners @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }

    }
}