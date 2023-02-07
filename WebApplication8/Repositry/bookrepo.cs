using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication6.Repositry
{
    public class bookrepo : Ibookrepo
    {

        //we make method that add bookModel to database  (book repostry must connect with DBconect
        //so we need to acess bookstorecontext class we make instance to this class in constrctor

        bookstorecontext _bookstorecontext = null;

        public bookrepo(bookstorecontext context)
        {
            _bookstorecontext = context;
        }

        public async Task<int> Addbook(bookModel book)     //we want to add this book
        {

            var newbook = new Book()          //newbook will added  have proprities in class books
            {
                authorName = book.authorName,       //we must have the deiltes of book givin in the parametre
                title = book.title,  //store the detiles of this book in newbook
                coverImgURl = book.coverImgURl,
                bookpdfURL = book.bookpdfURL

            };

            await _bookstorecontext.Book.AddAsync(newbook);  //we added newbook to database with model book creted in folder data
            await _bookstorecontext.SaveChangesAsync();        //save changes in the database

            return newbook.id;
        }    //then we must use this method in controller in method Add new book when form submit







        //book => title , author 
        //book Model => list of book
        public async Task<List<bookModel>> getALLbook()
        {
            var bookslistbookModel = new List<bookModel>();    //obj of type return 
            var booklistbook = await _bookstorecontext.Book.ToListAsync();      //type list <book> but return type must be List<bookModel> 

            if (booklistbook?.Any() == true)          //if allbook contain any element 
            {
                foreach (var item in booklistbook)   //loop for every element in allbooks and convert it to type return List<bookModel>
                {
                    bookslistbookModel.Add(new bookModel()
                    {
                        authorName = item.authorName,
                        title = item.title,
                        id = item.id,
                        coverImgURl = item.coverImgURl,
                        bookpdfURL = item.bookpdfURL
                    });

                }
            }
            return bookslistbookModel;
        }

        public async Task<bookModel> getbookbyid(int ID)
        {
            var objbook = await _bookstorecontext.Book.FindAsync(ID);   //get the element by primry key 
            //var objbook = await _bookstorecontext.books.Where(x => x.id == ID).FirstOrDefaultAsync(); //type books (separted proprites)
            if (objbook != null)
            {
                var objbookmodel = new bookModel()
                {
                    authorName = objbook.authorName,
                    title = objbook.title,
                    id = objbook.id,
                    coverImgURl = objbook.coverImgURl,
                    bookpdfURL = objbook.bookpdfURL
                };
                return objbookmodel;
            }
            return null;
        }


        //public List<bookModel> getspesficbook(string Title, string Auth)
        //{

        //    return Book().Where(x => x.title == Title && x.authorName == Auth).ToList();

        //}

        //database of bybook assume that all of them stored in methed private
        ///id title authorName
    

        public async Task<List<bookModel>> getTopbook()
        {

            return await _bookstorecontext.Book.Select(book => new bookModel()
            {
                title  = book.title,
                authorName = book.authorName,
                coverImgURl = book.coverImgURl,
                bookpdfURL = book.bookpdfURL
            }).Take(5).ToListAsync();
        }

    }
}

