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
  public class DogsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    public DogsController(AnimalShelterContext db)
    {
      _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<Pagination>> Get(string name, int age, string gender, string description, string size, int page, int perPage)
    {
      IQueryable<Dog> query = _db.Dogs.AsQueryable();
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
      if (size != null)
      {
        query = query.Where(entry => entry.Size == size);
      }

      List<Dog> dogs = await query.ToListAsync();

      if (perPage == 0) perPage = 2;

      int total = dogs.Count;
      List<Dog> dogsPage = new List<Dog>();

      if (page < (total / perPage))
      {
        dogsPage = dogs.GetRange(page * perPage, perPage);
      }

      if (page == (total / perPage))
      {
        dogsPage = dogs.GetRange(page * perPage, total - (page * perPage));
      }

      return new Pagination()
      {
        DogData = dogsPage,
        Total = total,
        PerPage = perPage,
        Page = page,
        PreviousPage = page == 0 ? $"/api/Dogs?page={page}" : $"/api/Dogs?page={page - 1}",
        NextPage = $"/api/Dogs?page={page + 1}",
      };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dog>> GetDog(int id)
    {
      Dog thisDog = await _db.Dogs.FindAsync(id);

      if (thisDog == null)
      {
        return NotFound();
      }
      return thisDog;
    }

    [HttpPost]
    public async Task<ActionResult<Dog>> Post(Dog thisDog)
    {
      _db.Dogs.Add(thisDog);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetDog), new { id = thisDog.DogId }, thisDog);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Dog thisDog)
    {
      if (id != thisDog.DogId)
      {
        return BadRequest();
      }

      _db.Entry(thisDog).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DogExists(id))
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
    private bool DogExists(int id)
    {
      return _db.Dogs.Any(c => c.DogId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDog(int id)
    {
      Dog thisDog = await _db.Dogs.FindAsync(id);
      if (thisDog == null)
      {
        return NotFound();
      }

      _db.Dogs.Remove(thisDog);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}