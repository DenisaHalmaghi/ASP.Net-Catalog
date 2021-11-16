using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mobile.Models;
namespace mobile.Controllers
{
  public class CatalogController : Controller
  {
    private readonly ApplicationDbContext _context;

    public CatalogController(ApplicationDbContext context)
    {
      _context = context;
    }
    // private ICatalogRepository repository;
    // public CatalogController(ICatalogRepository repo)
    // {
    //   repository = repo;
    // }
    // public ViewResult List() => View(repository.Catalogs);

    // GET: Intrari1
    public async Task<IActionResult> Index()
    {
      return View(await _context.Catalogs.ToListAsync());
    }

    // GET: Catalog/Create
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,marca,nume,prenume,nota1,nota2")] Catalog catalog)
    {
      if (ModelState.IsValid)
      {
        _context.Add(catalog);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(catalog);
    }
  }

}