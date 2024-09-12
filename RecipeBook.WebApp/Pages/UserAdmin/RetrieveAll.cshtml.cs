using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Livro_de_Receita.modelo;
using System.Text.Json;
using Livro_de_Receita.service.implemetations;

namespace RecipeBook.WebApp.Pages.UserAdmin
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IUserService _service;
        public RetrieveAllModel (IUserService service)
        {
            _service = service;
        }

        public List<User> Users = new List<User>();
        public void OnGet()
        {
            Users = _service.RetrieveAll();
        }
        public void OnPost()
        {
            string username = Convert.ToString(Request.Form["username"]);
            string password = Convert.ToString(Request.Form["password"]);

            User user = _service.Login(username, password);

            string jsonString = JsonSerializer.Serialize(user);
            HttpContext.Session.SetString("user", jsonString);

        }

    }
}
