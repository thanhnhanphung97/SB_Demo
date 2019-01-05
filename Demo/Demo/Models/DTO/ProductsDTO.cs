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
        private int id;
        private int idList;
        private string name;
        private string doc;
        private string img;

        [Required(ErrorMessage = "This is a required field.")]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        [Required(ErrorMessage = "This is a required field.")]
        public int IdList
        {
            get
            {
                return idList;
            }

            set
            {
                idList = value;
            }
        }

        [Required(ErrorMessage = "This is a required field.")]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        [Required(ErrorMessage = "This is a required field.")]
        public string Doc
        {
            get
            {
                return doc;
            }

            set
            {
                doc = value;
            }
        }

        [Required(ErrorMessage = "This is a required field.")]
        public string Img
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
            }
        }
    }
}