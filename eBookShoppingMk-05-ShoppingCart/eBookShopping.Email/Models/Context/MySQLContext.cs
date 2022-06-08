using Microsoft.EntityFrameworkCore;

namespace eBookShopping.Email.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<EmailLog> Emails { get; set; }
    }
}