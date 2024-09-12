using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _categoryService.RetrieveAll();
        }
        public IActionResult OnPost(Category category)
        {
            _categoryService.Create(category);
            return RedirectToAction("Create");
        }
    }
}
