using System.Linq;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace mobile.Models
{
  public static class SeedData
  {
    public static void EnsurePopulated(IApplicationBuilder app)
    {

      // var scopeeee = app.ApplicationServices.CreateScope();
      // ApplicationDbContext context = scopeeee.ServiceProvider.GetRequiredService<ApplicationDbContext>();
      ApplicationDbContext context = app.ApplicationServices
      .GetRequiredService<ApplicationDbContext>();
      context.Database.Migrate();
      if (!context.Catalogs.Any())
      {
        context.Catalogs.AddRange(
          new Catalog
          {
            nume = "popescu",
            prenume = "ana",
            nota1 = 10,
            nota2 = 9,
            marca = "gucci"
          },
          new Catalog
          {
            nume = "ionesscu",
            prenume = "maria",
            nota1 = 8,
            nota2 = 9,
            marca = "armani"
          },
          new Catalog
          {
            nume = "fix",
            prenume = "pix",
            nota1 = 8,
            nota2 = 9,
            marca = "armani"
          }
        );
        context.SaveChanges();
      }
    }
  }
}