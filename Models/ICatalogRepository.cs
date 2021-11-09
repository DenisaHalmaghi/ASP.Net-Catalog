using System.Linq;
namespace mobile.Models
{
  public interface ICatalogRepository
  {
    IQueryable<Catalog> Catalogs { get; }
  }
}