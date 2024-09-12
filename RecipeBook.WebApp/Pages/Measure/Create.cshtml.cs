using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Measure
{
    public class CreateModel : PageModel
    {
        private readonly IMeasuresService _measuresService;
        public CreateModel (IMeasuresService measures)
        {
            _measuresService = measures;
        }
        public Measures Measures { get; set; }
        public List<Measures> Measure { get; set; }
        public void OnGet()
        {
            Measure = _measuresService.RetrieveAll();
        }
        public IActionResult OnPost(Measures measures)
        {
            _measuresService.Create(measures);
            return RedirectToAction("Create");
        }
    }
}
