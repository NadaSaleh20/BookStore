using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Repositry;
using WebApplication8.Helper;

namespace WebApplication8.Models
{

    public class bookModel
    {
       
      
        public int id { get; set; }

        //[CustomValidtion( text ="nada")]
        [Required]
        public string title { get; set; }
       
        [Display (Name ="Author")]
        [Required]
        public string authorName { get; set;}

        [Display(Name = "book cover")]
        [Required]
        public IFormFile coverbook { get; set; }

        public string coverImgURl { get; set; }


        [Display(Name = "Uploade pdf file for your book")]
        [Required]
        public IFormFile bookpdf { get; set; }

        public string bookpdfURL { get; set; }



    }
}