using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeBook.WebApp.Pages.Users

{

    public class CreateModel : PageModel
    {
        private readonly IUserService _service;
        public User User { get; set; }
        public CreateModel (IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost(User user)
        {
            _service.Create(user);
            return RedirectToPage("/Account/Login");
        }
    }
}
