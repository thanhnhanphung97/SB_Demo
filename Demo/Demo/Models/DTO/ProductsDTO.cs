using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Models.DTO
{
    public class ProductsDTO
    {
        public ProductsDTO(int id,int idList,string name,string doc,string img)
        {
            this.Id = id;
            this.IdList = idList;
            this.Name = name;
            this.Doc = doc;
            this.Img = img;
        }

        public ProductsDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.IdList = (int)row["IdList"];
            this.Name = row["Name"].ToString();
            this.Doc = row["Doc"].ToString();
            this.Img = row["Img"].ToString();
        }

        private int id;
        private int idList;
        private string name;
        private string doc;
        private string img;

        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public int IdList { get => idList; set => idList = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Name { get => name; set => name = value; }
        [AllowHtml]
        [Required(ErrorMessage = "This is a required field.")]
        public string Doc { get => doc; set => doc = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Img { get => img; set => img = value; }
    }
}