using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.UnRegisted
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;
        public RetrieveAllModel(IRecipeService recipeService, IUserService userService)
        {
            _recipeService = recipeService;
            _userService = userService;
        }

        public User User { get; set; }
       public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public Ingredient Ingredient { get; set; }

        public void OnGet()
        {

            Recipes = _recipeService.RetrieveAll();
        }


    }
}
