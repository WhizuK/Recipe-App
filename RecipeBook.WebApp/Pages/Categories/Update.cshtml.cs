using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Categories
{
    public class UpdateModel : PageModel
    {

        private readonly ICategoryService _service;
        public UpdateModel(ICategoryService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            Category = _service.Retrieve(id);
        }
        public Category Category { get; set; }
        public IActionResult OnPost(Category category)
        {

            _service.Update(category);
            return Redirect("/Categories/Create");
        }
    }
}
