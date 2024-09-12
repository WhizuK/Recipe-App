using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Difficulties
{
    public class CreateModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;
       public Difficulty Difficulty { get; set; }
        public CreateModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }
        public List<Difficulty> difficulties { get; set; }
        public void OnGet()
        {
            difficulties = _difficultyService.RetrieveAll();
        }
        public IActionResult OnPost(Difficulty difficulty)
        {
            _difficultyService.Create(difficulty);
            return RedirectToAction("Create");
        }
    }
}
