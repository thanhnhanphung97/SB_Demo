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

        public int Id { get; set; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Img { get; set; }
        [Required(ErrorMessage = "This is a required field.")]
        public float Data { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "This is a required field.")]
        public string Describe { get; set; }
        [Required(ErrorMessage = "This is a required field.")]
        public string Color { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}