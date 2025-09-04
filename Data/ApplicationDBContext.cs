using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWeb.Models;
namespace MyWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        //ctor
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
    //2 video api net
    //hieu code 11h45
}