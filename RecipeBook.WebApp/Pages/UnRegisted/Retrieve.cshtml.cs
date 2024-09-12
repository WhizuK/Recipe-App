using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.UnRegisted
{
    public class RetrieveModel : PageModel
    {
        private readonly IRecipeService _service;
        public User User { get; set; }
        public Recipe Recipe { get; set; } 
        public RetrieveModel(IRecipeService service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {

            Recipe = _service.Retrieve(id);
        }

    }
}
