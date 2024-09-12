using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Favorites
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IUserService _userService;

        public RetrieveAllModel(IFavoriteService favoriteService, IUserService userService)
        {
            _favoriteService = favoriteService;
            _userService = userService;
        }

        public User User { get; set; }
        public List<Favorite> Favorites = new List<Favorite>();
        public void OnGet()
        {
            User = GetSessionUser();

            if (User == null)
            {
                RedirectToPage("/Account/Login");
            }
            Favorites =_favoriteService.RetrieveAll();
            
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
