using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.RecipesAdmin
{
    public class PendingRecipes : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;
        public PendingRecipes(IRecipeService recipeService, IUserService userService)
        {
            _recipeService = recipeService;
            _userService = userService;
        }

        public User User { get; set; }
        public Recipe Recipe { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public Ingredient Ingredient { get; set; }
        [BindProperty]
        public bool IsApproved { get; set; }

        public IActionResult OnGet(int id)
        {
            GetSessionUser();
            Recipe = _recipeService.Retrieve(id);
            return Page();
        }
        public IActionResult OnPost(Recipe recipe)
        {
            _recipeService.Update(recipe);
            return Redirect("/RecipesAdmin/PendingList");
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
