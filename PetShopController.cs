using Microsoft.AspNetCore.Mvc;
using PetShopWebsite.Models;
using PetShopWebsite.Repositories;
namespace PetShopWebsite.Controllers
{

    public class PetShopController : Controller
    {
        private readonly IRepository _repository;
        public PetShopController(IRepository repository)
        {
            _repository = repository;

        }

        public IActionResult Home()
        {
            return View(_repository.GetMostCommentedAnimals());
        }

        public IActionResult Catalog(string animalType)
        {
            //Unless a category was chosen, display all the categories. 

            var animals = string.IsNullOrEmpty(animalType)
                ? _repository.GetAllAnimals()
                : _repository.GetAnimalsByType(animalType);

            return View(animals);
        }

        //Get animal's details

        [HttpGet]
        public IActionResult Animal(int id)
        {
            var animal = _repository.GetAnimalById(id);
            _ = _repository.GetCategoryById(animal.CategoryId);
            if (animal == null)
            {
                return NotFound();
            }
            var comments = _repository.GetComments(id);
            ViewBag.Comments = comments;

            return View(animal);
        }

        //Enable adding comments

        [HttpPost]
        public IActionResult Animal(int id, string comment)
        {
            var animal = _repository.GetAnimalById(id);

            if (animal == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var newComment = new Comment
                {
                    Comment1 = comment,
                    AnimalId = id
                };
                _repository.AddComment(newComment);
            }

            return RedirectToAction(nameof(Animal), new { id });
        }

        public IActionResult Administrator(string type)
        {
            var categories = _repository.GetCategories();
            ViewData["Categories"] = categories;
            var animals = string.IsNullOrEmpty(type) ? null : _repository.GetAnimalsByType(type);
            return View(animals);
        }

        public IActionResult DeleteAnimal(int id)
        {
            var animal = _repository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
            _repository.RemoveAnimal(animal);
            return RedirectToAction(nameof(Administrator));
        }

        [HttpGet]
        public IActionResult NewAnimal()
        {
            ViewBag.Categories = _repository.GetCategories();
            var animal = new Animal();
            return View(animal);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> NewAnimal(Animal animal, IFormFile pictureName)
        {
            // Check required fields separately and add model errors if they are empty
            if (string.IsNullOrWhiteSpace(animal.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
               
            }

            if (animal.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Category is required");
            }

            if (pictureName == null)
            {
                ModelState.AddModelError("pictureName", "Picture is required");
            }

            // If there are any model errors, notify the user and return to the form with the entered data
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Please fill out all required fields and upload a picture.";
                ViewBag.Categories = _repository.GetCategories();
                return View(animal);
            }

            //Upload a picture
            string fileName = Path.GetFileName(pictureName!.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await pictureName.CopyToAsync(fileStream);
            animal.PictureName = fileName;

            // Save the animal and redirect to the administrator page
            _repository.AddAnimal(animal);
            return RedirectToAction(nameof(Administrator));
        }




        [HttpGet]
        public IActionResult EditAnimal(int id)
        {
            Animal animal = _repository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _repository.GetCategories();
            return View(animal);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnimal( Animal animal, IFormFile pictureName)
        {
            
            // Check if a new picture is uploaded

            if (pictureName != null)
            {
                string fileName = Path.GetFileName(pictureName.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                await pictureName.CopyToAsync(fileStream);
                animal.PictureName = pictureName.FileName;
            }
            else
            {
               
                // Get the existing animal from the repository
                // Set the PictureName to the original value

                var existingAnimal = _repository.GetAnimalById(animal.AnimalId);
                animal.PictureName = existingAnimal.PictureName;
            }

            // Check if name is empty and add a model error if it is
            if (string.IsNullOrEmpty(animal.Name))
            {
                ModelState.AddModelError("Name", "Name can't be empty");
                
            }

            // Check if category is not selected and add a model error if it is
            if (animal.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Category must be chosen");
            }


            // Only if there's another missing input in addition to the image, stay on this page. 
            if (!ModelState.IsValid && ModelState.ErrorCount > 1)
            {
                ViewBag.Categories = _repository.GetCategories();
                return View(animal);
            }



            // Update the animal
            await _repository.UpdateAnimal(animal);
            return RedirectToAction(nameof(Administrator));
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            await _repository!.DeleteComment(commentId);
            return RedirectToAction(nameof(Catalog));

        }




















    }
}

