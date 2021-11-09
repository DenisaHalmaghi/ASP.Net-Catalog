using System.Collections.Generic;
using System.Linq;
namespace mobile.Models
{
  public class EFCatalogRepository : ICatalogRepository
  {
    private ApplicationDbContext context;
    public EFCatalogRepository(ApplicationDbContext ctx)
    {
      context = ctx;
    }
    public IQueryable<Catalog> Catalogs => context.Catalogs;
  }
}