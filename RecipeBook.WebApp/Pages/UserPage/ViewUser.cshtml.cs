using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.UserPage
{
    public class ViewUserModel : PageModel
    {
        private readonly IUserService _userService;
        public ViewUserModel(IUserService userService)
        {
            _userService = userService;
        }
        public User User { get; set; }
        public void OnGet()
        {
            User = GetSessionUser();
        }
        private User GetSessionUser()
        {
            string user = HttpContext.Session.GetString("user");

            if (user is not null)
            {
                User u = JsonSerializer.Deserialize<User>(user);
                return u;
            }

            return null;
        }

    }
}
