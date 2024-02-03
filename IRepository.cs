using PetShopWebsite.Models;

namespace PetShopWebsite.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animal> GetMostCommentedAnimals();
        IEnumerable<Animal> GetAllAnimals();
        List<Animal> GetAnimalsByType(string type);
        Animal GetAnimalById(int id);
        void AddComment(Comment comment);
        IEnumerable<Comment> GetComments(int animalId);
        List<Category> GetCategories();
        void RemoveAnimal(Animal animal);
        void AddAnimal(Animal animal); 
        Category GetCategoryById(int categoryId);
        Task UpdateAnimal(Animal animal);
        Task DeleteComment(int commentId);
       

    }
}

