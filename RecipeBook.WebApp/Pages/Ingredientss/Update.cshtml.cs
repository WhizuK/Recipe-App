using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Ingredientss
{
    public class UpdateModel : PageModel
    {
        private readonly IIngredientsService _ingredientsService;
        public UpdateModel(IIngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }
        public Ingredient Ingredient { get; set; }
        public void OnGet(int id)
        {
            Ingredient = _ingredientsService.Retrieve(id);
        }
        public IActionResult OnPost(Ingredient ingredient)
        {
            _ingredientsService.Update(ingredient);
            return Redirect("/Ingredientss/Create");
        }
    }
}
