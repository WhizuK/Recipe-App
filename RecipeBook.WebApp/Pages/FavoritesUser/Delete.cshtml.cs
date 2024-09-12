using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Favorites
{
    public class DeleteeModel : PageModel
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IUserService _userService;

        public DeleteeModel(IFavoriteService favoriteService, IUserService userService)
        {
            _favoriteService = favoriteService;
            _userService = userService;
        }

        public User User { get; set; }
        public List<Favorite> Favorites { get; set; }

        public IActionResult OnGet(int id)
        {
            _favoriteService.Delete(id);
            return RedirectToPage("/UserPage/MainPageUser");
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
