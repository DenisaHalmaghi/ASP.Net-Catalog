// using Microsoft.EntityFrameworkCore;

// using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace mobile.Models
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }
    public DbSet<Catalog> Catalogs { get; set; }
  }
}
