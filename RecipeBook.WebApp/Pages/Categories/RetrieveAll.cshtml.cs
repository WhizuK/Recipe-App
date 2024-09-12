using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Categories
{
    public class RetrieveAllModel : PageModel
    {
        private readonly ICategoryService _service;
        public RetrieveAllModel(ICategoryService service)
        {
            _service = service;
        }
        public List<Category> categories { get; set; }
        public void OnGet()
        {
            categories = _service.RetrieveAll();
        }
    }
}
