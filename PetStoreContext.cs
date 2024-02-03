using Microsoft.EntityFrameworkCore;

namespace PetShopWebsite.Models;

public partial class PetStoreContext : DbContext
{
    public PetStoreContext()
    {
    }

    public PetStoreContext(DbContextOptions<PetStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal>? Animals { get; set; }


    public virtual DbSet<Category>? Categories { get; set; }

    public virtual DbSet<Comment>? Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region AnimalData
        modelBuilder.Entity<Animal>().HasData(
            new
            {
                AnimalId = 1,
                Name = "Lion",
                Age = 4,
                PictureName = "Lion.png",
                Description =
            "Lions have strong, compact bodies and powerful forelegs, teeth and jaws for pulling down and" +
            " killing prey. Their coats are yellow-gold, and adult males have shaggy manes that range in" +
            " color from blond to reddish-brown to black. The length and color of a lion's mane is" +
            " likely determined by age, genetics and hormones.",
                CategoryId = 1
            },
            new
            {
                AnimalId = 2,
                Name = "Dog",
                Age = 14,
                PictureName = "Dog.png",
                Description = "A dog is a domestic mammal of the family Canidae" +
            " and the order Carnivora. Its scientific name is Canis lupus familiaris. Dogs are a subspecies of the gray wolf, and they are" +
            " also related to foxes and jackals. Dogs are one of the two most ubiquitous and most popular domestic animals in the world."
            ,
                CategoryId = 1
            },
            new
            {
                AnimalId = 3,
                Name = "Elephant",
                age = 20,
                PictureName = "Elephant.png",
                Description =
            "Elephants are the largest land mammals on earth and have distinctly massive bodies, large ears, and long trunks. " +
            "They use their trunks to pick up objects, trumpet warnings, greet other elephants, or suck up water for drinking or bathing," +
            " among other uses.",
                CategoryId = 1
            },
            new
            {
                AnimalId = 4,
                Name = "Tiger",
                Age = 8,
                PictureName = "Tiger.png",
                Description = "Tigers have reddish-orange coats with " +
            "prominent black stripes, white bellies and white spots on their ears. Like a human fingerprint, no two tigers have the exact" +
            " same markings. Because of this, researchers can use stripe patterns to identify different individuals when studying tigers" +
            " in the wild.",
                CategoryId = 1
            },
            new
            {
                AnimalId = 5,
                Name = "Salmon",
                Age = 1,
                PictureName = "Salmon.png",
                Description = "Chinook salmon are the largest of the seven" +
            " Pacific salmon species. Like all salmon, they’re anadromous—they migrate between freshwater and the open ocean throughout " +
            "their lifetimes. Nine populations of chinook salmon are protected under the Endangered Species Act.",
                CategoryId = 2
            },
            new
            {
                AnimalId = 6,
                Name = "Axolotl",
                Age = 2,
                PictureName = "Axolotl.png",
                Description = "Axolotls are also known as Mexican walking" +
            " fish. Their name stems from an Aztec word meaning water dog or water monster. Axolotls have cylindrical bodies, short legs," +
            " a relatively long tail and feathery external gills. They have four toes on the front feet, five toes on the back feet and " +
            "moveable eyelids.",
                CategoryId = 2
            },
            new
            {
                AnimalId = 7,
                Name = "Great white shark",
                Age = 6,
                PictureName = "GreatWhiteShark.png",
                Description = "Found in cool, coastal waters around the world, great whites are the largest predatory fish on Earth. " +
                "They grow to an average of 15 feet in length, though specimens exceeding 20 feet and weighing up to 5,000 pounds have " +
                "been recorded.",
                CategoryId = 2
            },
            new
            {
                AnimalId = 8,
                Name = "Eagle",
                Age = 8,
                PictureName = "Eagle.png",
                Description = "In general, an eagle is any bird of prey more powerful than a buteo. An eagle may resemble a vulture in build and flight characteristics but has a fully feathered (often crested) head and strong feet equipped with great curved talons. A further difference is in foraging habits: eagles subsist mainly on live prey.",
                CategoryId = 3
            },
            new
            {
                AnimalId = 9,
                Name = "Parrot",
                Age = 12,
                PictureName = "Parrot.png",
                Description = "Characteristic features of parrots include a strong, curved bill, an upright stance, strong legs, and clawed zygodactyl feet. Many parrots are vividly coloured, and some are multi-coloured. Most parrots exhibit little or no sexual dimorphism in the visual spectrum.",
                CategoryId = 3
            },
            new
            {
                AnimalId = 10,
                Name = "Crocodile",
                Age = 23,
                PictureName = "Crocodile.png",
                Description = "crocodile, (order Crocodylia, or Crocodilia), any of 23 species of generally large, ponderous, amphibious animals of lizard-like appearance and carnivorous habit belonging to the reptile order Crocodylia. Crocodiles have powerful jaws with many conical teeth and short legs with clawed webbed toes.",
                CategoryId = 4
            },
            new
            {
                AnimalId = 11,
                Name = "Turtle",
                Age = 250,
                PictureName = "Turtle.png",
                Description = "turtle, (order Testudines), any reptile with a body encased in a bony shell, including tortoises. Although numerous animals, from invertebrates to mammals, have evolved shells, none has an architecture like that of turtles. The turtle shell has a top (carapace) and a bottom (plastron).",
                CategoryId = 4
            },
            new
            {
                AnimalId = 12,
                Name = "Frog",
                Age = 1,
                PictureName = "Frog.png",
                Description = "Common frogs have smooth skin that varies in colour from grey, olive green and yellow to brown. They have irregular dark blotches, a dark stripe around their eyes and eardrum, and dark bars on their legs. They are able to lighten or darken their skin to match their surroundings.",
                CategoryId = 5
            },
             new
             {
                 AnimalId = 13,
                 Name = "Hipo",
                 Age = 12,
                 PictureName = "Frog.png",
                 Description = "Check",
                 CategoryId = 1
             }


            );
        #endregion
        #region CtegoryData

        modelBuilder.Entity<Category>().HasData(
            new
            {
                CategoryId = 1,
                Name = "Mammals"
            },
            new
            {
                CategoryId = 2,
                Name = "Fish"
            },
            new
            {
                CategoryId = 3,
                Name = "Birds"
            },
            new
            {
                CategoryId = 4,
                Name = "Reptiles"
            },
            new
            {
                CategoryId = 5,
                Name = "Amphibians"
            }
           
            ); 
        #endregion
        #region CommentData
        modelBuilder.Entity<Comment>().HasData(
            new
            {
                CommentId = 1,
                Comment1 = "I love dogs. Used to have a female dog for 14 years.",
                AnimalId = 2
            },

            new
            {
                CommentId = 2,
                Comment1 = "Crocodiles are so scary! They have the strongest bite in the animal kingdom!!!",
                AnimalId = 10
            },

            new
            {
                CommentId = 3,
                Comment1 = "Dogs are so loyal, I just love them.",
                AnimalId = 2
            }
            
            );
        #endregion

    }


}