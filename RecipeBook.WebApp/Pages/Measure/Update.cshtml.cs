using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Measure
{
    public class UpdateModel : PageModel
    {
        private readonly IMeasuresService _measuresService;
        public UpdateModel(IMeasuresService measuresService)
        {
            _measuresService= measuresService;
        }
        public Measures Measures { get; set; }
        public void OnGet(int id)
        {
            Measures = _measuresService.Retrieve(id);
        }
        public IActionResult OnPost(Measures measures)
        {
            _measuresService.Update(measures);
            return Redirect("/Measure/Create");
        }
    }
}
