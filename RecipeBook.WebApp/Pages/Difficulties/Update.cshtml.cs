using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Difficulties
{
    public class UpdateModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;
        public UpdateModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }
        public Difficulty Difficulty { get; set; }
        public void OnGet(int id)
        {
            Difficulty = _difficultyService.Retrieve(id);
        }
        public IActionResult OnPost(Difficulty difficulty)
        {
            _difficultyService.Update(difficulty);
            return Redirect("/Difficulties/Create");
        }
    }
}
