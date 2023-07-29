using Asp.net_MVC_app_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_MVC_app_CRUD.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
             
        }
        public DbSet<Category> Categories { get; set; }
    }
}
