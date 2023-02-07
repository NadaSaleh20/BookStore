using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Data
{
    public class bookstorecontext : IdentityDbContext<Users>
    {
        public bookstorecontext(DbContextOptions<bookstorecontext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=bookstore;Trusted_Connection=True;");
        //    base.OnConfiguring(optionsBuilder);

        //}
    }
}
