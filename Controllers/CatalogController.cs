using Microsoft.AspNetCore.Mvc;
using mobile.Models;
namespace mobile.Controllers
{
  public class CatalogController : Controller
  {
    private ICatalogRepository repository;
    public CatalogController(ICatalogRepository repo)
    {
      repository = repo;
    }
    public ViewResult List() => View(repository.Catalogs);
  }

}