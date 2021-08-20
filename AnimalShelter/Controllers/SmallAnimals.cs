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
  public class SmallAnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    public SmallAnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SmallAnimal>>> Get(string name, int age, string description, string gender)
    {
      IQueryable<SmallAnimal> query = _db.SmallAnimals.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (age != 0)
      {
        query = query.Where(entry => entry.Age == age);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }
      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SmallAnimal>> GetSmallAnimal(int id)
    {
      SmallAnimal thisSmallAnimal = await _db.SmallAnimals.FindAsync(id);

      if (thisSmallAnimal == null)
      {
        return NotFound();
      }
      return thisSmallAnimal;
    }
    
    [HttpPost]
    public async Task<ActionResult<SmallAnimal>> Post(SmallAnimal thisSmallAnimal)
    {
      _db.SmallAnimals.Add(thisSmallAnimal);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetSmallAnimal), new { id = thisSmallAnimal.SmallAnimalId }, thisSmallAnimal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, SmallAnimal thisSmallAnimal)
    {
      if (id != thisSmallAnimal.SmallAnimalId)
      {
        return BadRequest();
      }

      _db.Entry(thisSmallAnimal).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!SmallAnimalExists(id))
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
    private bool SmallAnimalExists(int id)
    {
      return _db.SmallAnimals.Any(c => c.SmallAnimalId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSmallAnimal(int id)
    {
      SmallAnimal thisSmallAnimal = await _db.SmallAnimals.FindAsync(id);
      if (thisSmallAnimal == null)
      {
        return NotFound();
      }

      _db.SmallAnimals.Remove(thisSmallAnimal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}