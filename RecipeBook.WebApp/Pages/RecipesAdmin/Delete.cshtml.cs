using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.RecipesAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeIgredientsService _recipeIgredientsService;
        public DeleteModel(IRecipeService recipeService, IRecipeIgredientsService recipeIgredientsService)
        {
            _recipeService = recipeService;
            _recipeIgredientsService = recipeIgredientsService;
        }
        public IActionResult OnGet(int id)
        {
            _recipeService.Delete(id);
            _recipeIgredientsService.Delete(id);
           
            return Redirect("/Admin/Admin");
        }
    }
}
