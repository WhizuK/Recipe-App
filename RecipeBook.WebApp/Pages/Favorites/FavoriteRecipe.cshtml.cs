using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Favorites
{
    public class FavoriteRecipeModel : PageModel
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IRecipeService _recipeService;

        public FavoriteRecipeModel(IFavoriteService favoriteService, IRecipeService recipeService)
        {
            _favoriteService = favoriteService;
            _recipeService = recipeService;
        }

        public List<Favorite> Favorites { get; set; }

        public void OnGet()
        {
            User user = GetSessionUser();

            if (user != null)
            {
                Favorites = _favoriteService.GetFavoritesByUserId(user.Id);
            }

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
