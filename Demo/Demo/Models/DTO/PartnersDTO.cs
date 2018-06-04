using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Models.DTO
{
    public class PartnersDTO
    {
        public PartnersDTO(int id,string name,string img,string describe,string background)
        {
            this.Id = id;
            this.Name = name;
            this.Img = img;
            this.Describe = describe;
            this.Background = background;
        }

        public PartnersDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["Name"].ToString();
            this.Img = row["Img"].ToString();
            this.Describe = row["Describe"].ToString();
            this.Background = row["Background"].ToString();
        }


        private int id;
        private string name;
        private string img;
        private string describe;
        private string background;

        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Name { get => name; set => name = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Img { get => img; set => img = value; }
        [AllowHtml]
        [Required(ErrorMessage = "This is a required field.")]
        public string Describe { get => describe; set => describe = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Background { get => background; set => background = value; }
    }
}