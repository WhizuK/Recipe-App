using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;

namespace Livro_de_Receita.WebApp.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientsService _ingredientsService;
        private readonly IMeasuresService _measuresService;
        private readonly IRecipeIgredientsService _recipeIngredientsService;
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;

        public CreateModel(
            IRecipeService recipeService,
            IIngredientsService ingredientsService,
            IMeasuresService measuresService,
            IRecipeIgredientsService recipeIngredientsService,
            ICategoryService categoryService,
            IDifficultyService difficultyService)
        {
            _recipeService = recipeService;
            _ingredientsService = ingredientsService;
            _measuresService = measuresService;
            _recipeIngredientsService = recipeIngredientsService;
            _categoryService = categoryService;
            _difficultyService = difficultyService; 
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<Measures> Measures { get; set; }
        public List<Category> Categories { get; set; }
        public List<Difficulty> Difficulties { get; set; } 

        [BindProperty]
        public List<int> IngredientIds { get; set; }
        [BindProperty]
        public List<double> Quantities { get; set; }
        [BindProperty]
        public List<int> MeasureIds { get; set; }

        public void OnGet()
        {
            Ingredients = _ingredientsService.RetrieveAll();
            Measures = _measuresService.RetrieveAll();
            Categories = _categoryService.RetrieveAll();
            Difficulties = _difficultyService.RetrieveAll(); 
        }

        public IActionResult OnPost(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                Ingredients = _ingredientsService.RetrieveAll();
                Measures = _measuresService.RetrieveAll();
                Categories = _categoryService.RetrieveAll();
                Difficulties = _difficultyService.RetrieveAll();
            }
            User user = GetSessionUser();
            if (user == null)
            {
               
                return RedirectToPage("/Account/Login");
            }

           
            Recipe.UserId = GetSessionUser(); 
            Recipe.Approved = false;


            Recipe createdRecipe = _recipeService.Create(Recipe);
            int PreparetionTime = 0;
            Recipe.PreparetionTime = PreparetionTime;


            if (IngredientIds.Count == Quantities.Count && IngredientIds.Count == MeasureIds.Count)
            {
                for (int i = 0; i < IngredientIds.Count; i++)
                {

                    var recipeIngredient = new RecipeIngredients
                    {
                        RecipeId = createdRecipe,
                        IngredientId = new Ingredient { Id = IngredientIds[i] },
                        Quantity = Quantities[i],
                        MeasureId = new Measures { Id = MeasureIds[i] }
                    };


                    _recipeIngredientsService.Create(recipeIngredient);
                }
            }

            return RedirectToPage("/UserPage/UserRecipe");
        }

        private User GetSessionUser()
        {
            string user = HttpContext.Session.GetString("user");

            if (user is not null)
            {
                User u = JsonSerializer.Deserialize<User>(user);
                return u;
            }

            return null; 
        }

    }
}
