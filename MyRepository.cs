using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using PetShopWebsite.Models;
using System.Diagnostics;

namespace PetShopWebsite.Repositories
{
    public class MyRepository : IRepository
    {
        private readonly PetStoreContext _context;

        public MyRepository(PetStoreContext context)
        {
            _context = context;

        }
        public IEnumerable<Animal> GetMostCommentedAnimals()
        {
            //Get animals with comments, order from top to bottom, take the first 2. 

            var animalsWithComments = _context.Animals!.Include(a => a.Comments);
            var sortedAnimals = animalsWithComments.OrderByDescending(a => a.Comments.Count());
            var topTwoAnimals = sortedAnimals.Take(2);
            return topTwoAnimals;
        }

        public IEnumerable<Animal> GetAllAnimals()
        {
            var animals = _context.Animals;
            return animals!;
        }



        public List<Animal> GetAnimalsByType(string type)
        {
            return _context.Animals!.Where(a => a.Category!.Name == type).ToList();
        }

        public Animal GetAnimalById(int animalId)
        {
            var animal = _context.Animals!.FirstOrDefault(a => a.AnimalId == animalId);
            return animal!;
        }

        public void AddComment(Comment comment)
        {

            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetComments(int animalId)
        {
            return _context.Comments!
                .Where(c => c.AnimalId == animalId)
                .ToList();
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _context.Comments!.FirstOrDefaultAsync(c => c.CommentId == commentId);
            if (comment != null)
            {
                _context.Comments!.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = _context.Categories!.FirstOrDefault(c => c.CategoryId == categoryId);

            return category!;

        }

        public List<Category> GetCategories()
        {
            return _context.Categories!.ToList();
        }

        public void RemoveAnimal(Animal animal)
        {
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }
        public void AddAnimal(Animal animal)
        {
            _ = _context.Animals!.AddAsync(animal);
            _context.SaveChangesAsync();

        }
        

        public async Task UpdateAnimal(Animal editedAnimal)
        {
            //Get existing animal
            var existingAnimal = await _context.Animals!.Where(a => a.AnimalId == editedAnimal.AnimalId).SingleOrDefaultAsync();

            if (existingAnimal != null)
            {
                //edit the animal's properties
                existingAnimal.Name = editedAnimal.Name;
                existingAnimal.Age = editedAnimal.Age;
                existingAnimal.CategoryId = editedAnimal.CategoryId;
                existingAnimal.Description = editedAnimal.Description;
                existingAnimal.PictureName = editedAnimal.PictureName;

                await _context.SaveChangesAsync();
            }
        }





    }
}
