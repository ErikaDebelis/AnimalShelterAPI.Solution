using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Cat>()
        .HasData(
          new Cat { CatId = 1, Name = "Kimmy", Description = "Soft, Long-hair, Lynx-point Neva Masquerade Siberian cat. Beauty, grace, and silly all at once. Was absolutely royalty in a past life.", Gender = "Female", Age = 8 },
          new Cat { CatId = 2, Name = "Max", Description = "Silly chonker. Very food motivated but a lovely companion and sweet natured. Is the yang to Betty's Yin- brother and sister- must adopt together.", Gender = "Male", Age = 2 },
          new Cat { CatId = 3, Name = "Betty", Description = "Sweet lil angel. Can be anxious around crowds or new people but is so sweet and demure when comfy. LOVES worm toy. Is the yin to Max's Yang- brother and sisters- must adopt together.", Gender = "Female", Age = 2 },
          new Cat { CatId = 4, Name = "Spike", Description = "Silly cute goof. Loves to cuddle and play. Little sweet ragdoll.", Gender = "Male", Age = 1 },
          new Cat { CatId = 5, Name = "Angel", Description = "Big fluff and like bird toys. will eat any food in sight but is so sweet and lovey you won't even mind. Will be a chonker one day.", Gender = "Male", Age = 1 }
        );
      builder.Entity<Dog>()
        .HasData(
          new Dog { DogId = 1, Name = "Cupcake", Description = "Lovely sweet baby- loves pets and licking the carpet lol.", Gender = "Female", Age = 8 },
          new Dog { DogId = 2, Name = "Muffin", Description = "Gentle pup with a lot of heart. Mr. loves Cupcake adn belly rubs.", Gender = "Male", Age = 10 },
          new Dog { DogId = 3, Name = "Cookie", Description = "Cookie is gentle and polite. Loves to love.", Gender = "Female", Age = 2 },
          new Dog { DogId = 5, Name = "Emma", Description = "The sweetest lil shih Tzu you'll ever meet. gets so excited to see you she pees a little but you don't mind cause its so sweet.", Gender = "Female", Age = 12 },
          new Dog { DogId = 4, Name = "Frankenfurter", Description = "Flamboyant lil boy with a tendency for drama. Very excitable fun pup.", Gender = "Male", Age = 7 }
        );
    }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }
  }
}