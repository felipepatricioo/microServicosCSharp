using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookShopping.CartAPI.Models.Context
{
    public class MySQLContext: DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }



    }
}
