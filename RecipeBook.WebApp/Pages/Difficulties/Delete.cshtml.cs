using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Difficulties
{
    public class DeleteModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;
        public Difficulty Difficulty { get; set; }
        public DeleteModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }
        public IActionResult OnGet(int id)
        {
            _difficultyService.Delete(id);
            return Redirect("/Difficulties/Create");
        }
    }
}
