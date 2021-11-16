using System.Linq;
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

    // GET: Catalogs1
    public async Task<IActionResult> Index()
    {
      return View(await _context.Catalogs.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var catalog = await _context.Catalogs
          .FirstOrDefaultAsync(m => m.id == id);
      if (catalog == null)
      {
        return NotFound();
      }

      return View(catalog);
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
    // GET: Catalogs1/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var catalog = await _context.Catalogs.FindAsync(id);
      if (catalog == null)
      {
        return NotFound();
      }
      return View(catalog);
    }

    // POST: Catalogs1/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,marca,nume,prenume,nota1,nota2")] Catalog catalog)
    {
      if (id != catalog.id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(catalog);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CatalogExists(catalog.id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(catalog);
    }

    // GET: Catalogs1/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var catalog = await _context.Catalogs
          .FirstOrDefaultAsync(m => m.id == id);
      if (catalog == null)
      {
        return NotFound();
      }

      return View(catalog);
    }

    // POST: Catalogs1/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var catalog = await _context.Catalogs.FindAsync(id);
      _context.Catalogs.Remove(catalog);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CatalogExists(int id)
    {
      return _context.Catalogs.Any(e => e.id == id);
    }
  }


}