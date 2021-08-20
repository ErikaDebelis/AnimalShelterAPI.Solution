using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Dog
  {
    public int DogId { get; set; }
    [Required]
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Description { get; set; }
    public string Size { get; set; }
  }
}