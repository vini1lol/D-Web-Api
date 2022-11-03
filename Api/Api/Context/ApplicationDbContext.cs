using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users {get;set;}
    }
}
