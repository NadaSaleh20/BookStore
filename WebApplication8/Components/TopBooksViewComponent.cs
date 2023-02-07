//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApplication6.Repositry;

//namespace WebApplication8.Components
//{

//    public class TopBooksViewComponent : ViewComponent
//    {
//        public bookrepo _bookrepo;
//        public TopBooksViewComponent(bookrepo bookrepo)
//        {
//            _bookrepo = bookrepo;
//        }
//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var books = await _bookrepo.getTopbook();
//            return View(books);
//        }
//    }
//}






