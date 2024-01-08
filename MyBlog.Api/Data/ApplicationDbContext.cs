using Microsoft.EntityFrameworkCore;
using MyBlog.Api.Models;

namespace MyBlog.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Article> Articles { get; set; }
}