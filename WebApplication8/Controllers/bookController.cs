using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication6.Repositry;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication6.Controllers
{
   
    public class bookController : Controller
    {
        public Ibookrepo _bookrepo;
        public IWebHostEnvironment _WebHostEnvironment;

        public bookController(Ibookrepo bookrepo , IWebHostEnvironment WebHostEnvironment)
        {
            _bookrepo = bookrepo;
            _WebHostEnvironment = WebHostEnvironment;
        }

        
        public async Task<ViewResult> getbooks()
        {
            var obj = await _bookrepo.getALLbook();
            return View(obj);
        }
        [HttpGet]

        [Route("~/book-Detiles/{id:int:min(1)}")]
        public async Task<ViewResult> getidbook(int id)
        {
            var obj = await _bookrepo.getbookbyid(id);
            return View(obj);
        }


        //public ViewResult getbookdetiles(string bookname, string authorname)
        //{
        //    var obj = _bookrepo.getspesficbook(bookname, authorname);

        //    return View(obj);
        //}

        [Authorize(Roles = "Admin")]
        public ViewResult AddnewBook(bool isadded = false ,int bookid=0 )  //just for the add element in the form 
        {
          
            ViewBag.isadded = isadded;
            ViewBag.bookid = bookid;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]  //when posting data that in  the form ,all data enterd will storted in the second method
        public async Task<IActionResult> AddnewBook(bookModel bookModel)   //all data enterted storted in  bookdetiliesadd
        {
            if (ModelState.IsValid)
            {
                //we must first make sure that img not null
                //and insert it in folder books/cover in wwwroot

                if (bookModel.coverbook != null)
                {
                    string folder = "books/cover/";

                    //we need to insert imgname in this folder books/cover/imgName
                    //Guid.NewGuid() =>Gloabel identifer to make uniqe coverbbokName
                    folder += Guid.NewGuid() + "_" + bookModel.coverbook.FileName;
                    bookModel.coverImgURl =$"/{folder}";
                    //we must update the path of serverside
                    //Path.Combine => combain two paths (server,folder )
                    string serverfolder =Path.Combine(_WebHostEnvironment.WebRootPath, folder);

                    //then we move this coverimg to folder in myproject
                    await bookModel.coverbook.CopyToAsync(new FileStream(serverfolder, FileMode.Create));

                }

                //for book pdf
                if (bookModel.bookpdf != null)
                {
                    string folder = "books/pdf/";
                    folder += Guid.NewGuid() + "_" + bookModel.bookpdf.FileName;
                    bookModel.bookpdfURL = $"/{folder}";
                    string serverfolder = Path.Combine(_WebHostEnvironment.WebRootPath, folder);
                    await bookModel.bookpdf.CopyToAsync(new FileStream(serverfolder, FileMode.Create));

                }
                int id = await _bookrepo.Addbook(bookModel);  //return type is id 
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddnewBook), new { isadded = true, bookid = id });
                    //when post data we want to return 
                    //to get method in the form (above method) 
                }
            }
           
            return View();          //we have to return type , then we change it to comptible one 
        }
    }
}

