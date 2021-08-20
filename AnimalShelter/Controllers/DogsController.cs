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
      var query = _db.Dogs.AsQueryable();
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
  }  
}  