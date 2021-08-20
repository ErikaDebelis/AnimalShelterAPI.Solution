using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class SmallAnimal
  {
    public int SmallAnimalId { get; set; }
    [Required]
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Description { get; set; }
  }
}