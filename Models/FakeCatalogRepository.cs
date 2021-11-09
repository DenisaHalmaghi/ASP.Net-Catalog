using System.Collections.Generic;
using System.Linq;
namespace mobile.Models
{
  public class FakeCatalogRepository : ICatalogRepository
  {
    public IQueryable<Catalog> Catalogs => new List<Catalog> {
      new Catalog { nume = "popescu", prenume = "ana", nota1=9, nota2=9, marca ="gucci" },
      new Catalog { nume = "ionesscu", prenume = "maria", nota1=8, nota2=9, marca ="armani" },
    }.AsQueryable<Catalog>();
  }
}