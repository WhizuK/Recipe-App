using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.RecipesAdmin
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

        public void OnGet()
        {
            GetSessionUser();
            Recipe = _service.Retrieve(2);
        }
        private void GetSessionUser()
        {
            string user = HttpContext.Session.GetString("user");

            if (user is not null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
