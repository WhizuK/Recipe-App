using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Ingredientss
{
    public class CreateModel : PageModel
    {
        private readonly IIngredientsService _ingredientsService;
        public CreateModel(IIngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }
        public Ingredient Ingredient { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public void OnGet()
        {
            ingredients = _ingredientsService.RetrieveAll();
        }
        public IActionResult OnPost(Ingredient ingredient) 
        {
            _ingredientsService.Create(ingredient);
            return RedirectToAction("Create");
        }
    }  
}
