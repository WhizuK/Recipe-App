using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Difficulties
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;
        public RetrieveAllModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }
        public List<Difficulty> difficulties { get; set; }
        public void OnGet()
        {
            difficulties = _difficultyService.RetrieveAll();
        }
    }
}
