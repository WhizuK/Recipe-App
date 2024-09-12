using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using Livro_de_Receita.service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.service.implemetations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;
        private readonly IRecipeIgredientsService _recipeIngredientsService;
        public RecipeService(IRecipeRepository repository, IUserService userService, ICategoryService categoryService, IDifficultyService difficultyService, IRecipeIgredientsService recipeIngredientsService)
        {
            _repository= repository;
            _userService= userService;
            _categoryService= categoryService;
            _difficultyService= difficultyService;
            _recipeIngredientsService = recipeIngredientsService;
        }


        public Recipe Create(Recipe recipe)
        {
            return _repository.Create(recipe);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Recipe Retrieve(int id)
        {
            Recipe recipe= _repository.Retrieve(id);
            recipe.UserId = _userService.Retrieve(recipe.UserId.Id);
            recipe.CategoryId = _categoryService.Retrieve(recipe.CategoryId.Id);
            recipe.DifficultyId = _difficultyService.Retrieve(recipe.DifficultyId.Id);
            recipe.RecipeIngredients = _recipeIngredientsService.RetrieveAll(recipe.Id);
            return recipe;
        }

        public List<Recipe> RetrieveAll()
        {
            List<Recipe> recipes = _repository.RetrieveAll();

            foreach (Recipe recipe in recipes)
            {
                recipe.UserId = _userService.Retrieve(recipe.UserId.Id);
                recipe.CategoryId = _categoryService.Retrieve(recipe.CategoryId.Id);
                recipe.DifficultyId = _difficultyService.Retrieve(recipe.DifficultyId.Id);

            }
            return recipes;
        }
        public Recipe Update(Recipe recipe)
        {
            return _repository.Update(recipe);

        }    
    }
}
