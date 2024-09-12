using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using System.Text.Json;

namespace Livro_de_Receita.WebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IUserService _userService;

        public CreateModel(IFavoriteService favoriteService, IUserService userService)
        {
            _favoriteService = favoriteService;
            _userService = userService;
        }

        public User User { get; set; }
        public List<Favorite> Favorites = new List<Favorite>();

       

        public IActionResult OnPost(Favorite favorite)
        {
            User = GetSessionUser();

            if (User == null)
            {
                return RedirectToPage("/Account/Login");
            }

            _favoriteService.Create(favorite);
            return Redirect("/Categories/RetrieveAll");
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

