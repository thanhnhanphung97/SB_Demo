using Demo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Demo.Models.DAO
{
    public class NewsDAO
    {
        private static NewsDAO instance;

        public static NewsDAO Instance { get { if (instance == null) instance = new NewsDAO(); return NewsDAO.instance; } private set => instance = value; }

        private NewsDAO() { }

        public List<NewsDTO> GetListNews()
        {
            List<NewsDTO> list = new List<NewsDTO>();

            string query = "USP_GetAll_News";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NewsDTO intro = new NewsDTO(item);
                list.Add(intro);
            }

            return list;
        }

        public bool InsertNews(string name, string img, string describe, string link)
        {
            link = "null";
            string query = "USP_Add_News @name , @img , @describe , @link";
            int result = DataProvider.Instance.ExecuteNonQuery(query,new object[] { name , img , describe , link });
            return result > 0;
        }

        public bool EditNews(int id, string name, string img, string describe, string link)
        {
            link = "null";
            string query = "USP_Edit_News @id , @name , @img , @describe , @link";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, img, describe, link });
            return result > 0;
        }

        public NewsDTO GetNews(int id)
        {
            string query = "USP_Get_News @id";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { id });

            foreach (DataRow item in data.Rows)
            {
                return new NewsDTO(item);
            }
            return null;
        }

        public bool DeleteNews(int id)
        {
            string query = "USP_Delete_News @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }

    }
}