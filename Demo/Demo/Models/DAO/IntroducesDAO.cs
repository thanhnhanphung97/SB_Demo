using Demo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Demo.Models.DAO
{
    public class IntroducesDAO
    {
        private static IntroducesDAO instance;

        public static IntroducesDAO Instance { get { if (instance == null) instance = new IntroducesDAO(); return IntroducesDAO.instance; } private set => instance = value; }

        private IntroducesDAO() { }

        public List<IntroducesDTO> GetListIntroducts()
        {
            List<IntroducesDTO> list = new List<IntroducesDTO>();

            string query = "USP_GetAll_Introduces";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                IntroducesDTO intro = new IntroducesDTO(item);
                list.Add(intro);
            }

            return list;
        }

        public bool InsertIntroduces(string name, string img, float data, string describe, string color)
        {
            string query = "USP_Add_Introduces @name , @img , @data , @describe , @color";
            int result = DataProvider.Instance.ExecuteNonQuery(query,new object[] { name , img , data , describe , color });
            return result > 0;
        }

        public bool EditIntroduces(int id, string name, string img, float data, string describe, string color)
        {
            string query = "EXEC USP_Edit_Introduces @id , @name , @img , @data , @describe , @color";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, img, data, describe, color });
            return result > 0;
        }

        public IntroducesDTO GetIntroducts(int id)
        {
            string query = "USP_Get_Introduces @id";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { id });

            foreach (DataRow item in data.Rows)
            {
                return new IntroducesDTO(item);
            }
            return null;
        }

        public bool DeleteIntroduces(int id)
        {
            string query = "USP_Delete_Introduces @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }

    }
}