using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookShopping.ProductAPI.Models.Context
{
    public class MySQLContext: DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Name",
                Price = new decimal(69.9),
                Description = "",
                CategoryName = "Romance",
                ImageUrl = ""

            });
        }

    }
}
