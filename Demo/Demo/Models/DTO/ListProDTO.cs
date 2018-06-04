using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Models.DTO
{
    public class ListProDTO
    {
        public ListProDTO(int id,int idList,string doc)
        {
            this.Id = id;
            this.IdList = idList;
            this.Doc = doc;
        }

        public ListProDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.IdList = (int)row["IdList"];
            this.Doc = row["Doc"].ToString();
        }

        private int id;
        private int idList;
        private string doc;


        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public int IdList { get => idList; set => idList = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Doc { get => doc; set => doc = value; }
    }
}