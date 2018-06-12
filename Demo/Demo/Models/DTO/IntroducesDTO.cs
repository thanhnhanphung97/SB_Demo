using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Models.DTO
{
    public class IntroducesDTO
    {
        public IntroducesDTO(int id,string name,string img,float data,string describe,string color)
        {
            this.Id = id;
            this.Name = name;
            this.Img = img;
            this.Data = data;
            this.Describe = describe;
            this.Color = color;
        }

        public IntroducesDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Name = row["Name"].ToString();
            this.Img = row["Img"].ToString();
            this.Data = (float)Convert.ToDouble(row["Data"].ToString());
            this.Describe = row["Describe"].ToString();
            this.Color = row["Color"].ToString();
        }


        private int id;

        private string name;

        private string img;

        private float data;

        private string describe;

        private string color;


        public int Id { get => id; set => id = value; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "This is a required field.")]
        public string Name { get => name; set => name = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Img { get => img; set => img = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public float Data { get => data; set => data = value; }
        [Required(ErrorMessage = "This is a required field.")]
        [AllowHtml]
        public string Describe { get => describe; set => describe = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Color { get => color; set => color = value; }
        //public HttpPostedFileBase ImageFile { get; set; }

    }
}