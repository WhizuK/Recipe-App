using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Measure
{
    public class DeleteModel : PageModel
    {
        private readonly IMeasuresService _measuresService;
        public DeleteModel(IMeasuresService measuresService)
        {
            _measuresService = measuresService;
        }

        public IActionResult OnGet(int id)
        {
            _measuresService.Delete(id);
            return Redirect("/Measure/Create");
        }
    }
}
