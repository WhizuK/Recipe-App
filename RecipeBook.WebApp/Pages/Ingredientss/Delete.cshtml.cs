using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Ingredientss
{
    public class DeleteModel : PageModel
    {
        private readonly IIngredientsService _ingredientsService;
        public DeleteModel(IIngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }
        
        public IActionResult OnGet(int id)
        {
            _ingredientsService.Delete(id);
            return Redirect("/Ingredientss/Create");
        }
    }
}
