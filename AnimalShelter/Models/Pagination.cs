using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class Pagination
  {
    public List<Cat> CatData { get; set; }
    public List<Dog> DogData { get; set; }
    public List<SmallAnimal> SmallAnimalData { get; set; }
    public int Total { get; set; }
    public int PerPage { get; set; }
    public int Page { get; set; }
    public string PreviousPage { get; set; }
    public string NextPage { get; set; }
  }
}