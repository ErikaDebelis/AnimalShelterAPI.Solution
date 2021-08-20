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
  }
}