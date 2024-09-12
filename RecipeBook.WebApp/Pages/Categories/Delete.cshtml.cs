using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _service;
        public DeleteModel (ICategoryService service) 
        {
            _service = service;
        }
        public IActionResult OnGet(int id)
        {
            _service.Delete(id);
            return Redirect("/Categories/Create");
        }
    }
}
