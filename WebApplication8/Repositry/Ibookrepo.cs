using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication6.Repositry
{
    public interface Ibookrepo
    {
        Task<int> Addbook(bookModel book);
        Task<List<bookModel>> getALLbook();
        Task<bookModel> getbookbyid(int ID);
        Task<List<bookModel>> getTopbook();
    }
}