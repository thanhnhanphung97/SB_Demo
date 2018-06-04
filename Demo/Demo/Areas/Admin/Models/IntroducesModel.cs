using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Models
{
    public class IntroducesModel
    {
        public IntroducesModel(int id, string name, string img, float data, string describe, string color)
        {
            this.Id = id;
            this.Name = name;
            this.Img = img;
            this.Data = data;
            this.Describe = describe;
            this.Color = color;
        }

        public IntroducesModel(DataRow row)
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
        [Required(ErrorMessage = "This is a required field.")]
        public string Name { get => name; set => name = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Img { get => img; set => img = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public float Data { get => data; set => data = value; }
        [AllowHtml]
        [Required(ErrorMessage = "This is a required field.")]
        public string Describe { get => describe; set => describe = value; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Color { get => color; set => color = value; }

    }
}