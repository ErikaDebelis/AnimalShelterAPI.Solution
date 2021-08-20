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
    public async Task<ActionResult<IEnumerable<Dog>>> Get(string name, int age, string description, string gender, string size)
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
      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }
      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }
      if (size != null)
      {
        query = query.Where(entry => entry.Size == size);
      }
      return await query.ToListAsync();
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
  }
}