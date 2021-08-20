using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    public CatsController(AnimalShelterContext db)
    {
      _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<Pagination>> Get(string name, int age, string gender, string description, int page, int perPage)
    {
      IQueryable<Cat> query = _db.Cats.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (age != 0)
      {
        query = query.Where(entry => entry.Age == age);
      }
      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }

      List<Cat> cats = await query.ToListAsync();

      if (perPage == 0) perPage = 2;

      int total = cats.Count;
      List<Cat> catsPage = new List<Cat>();

      if (page < (total / perPage))
      {
        catsPage = cats.GetRange(page * perPage, perPage);
      }

      if (page == (total / perPage))
      {
        catsPage = cats.GetRange(page * perPage, total - (page * perPage));
      }

      return new Pagination()
      {
        CatData = catsPage,
        Total = total,
        PerPage = perPage,
        Page = page,
        PreviousPage = page == 0 ? $"/api/Cats?page={page}" : $"/api/Cats?page={page - 1}",
        NextPage = $"/api/Cats?page={page + 1}",
      };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cat>> GetCat(int id)
    {
      Cat thisCat = await _db.Cats.FindAsync(id);

      if (thisCat == null)
      {
        return NotFound();
      }
      return thisCat;
    }

    [HttpPost]
    public async Task<ActionResult<Cat>> Post(Cat thisCat)
    {
      _db.Cats.Add(thisCat);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCat), new { id = thisCat.CatId }, thisCat);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cat thisCat)
    {
      if (id != thisCat.CatId)
      {
        return BadRequest();
      }

      _db.Entry(thisCat).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CatExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    private bool CatExists(int id)
    {
      return _db.Cats.Any(c => c.CatId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCat(int id)
    {
      Cat thisCat = await _db.Cats.FindAsync(id);
      if (thisCat == null)
      {
        return NotFound();
      }

      _db.Cats.Remove(thisCat);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}