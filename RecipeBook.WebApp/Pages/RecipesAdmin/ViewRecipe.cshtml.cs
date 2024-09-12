using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.RecipesAdmin
{
    public class ViewRecipeModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        IFavoriteService _favoriteService;
        public ViewRecipeModel(IRecipeService recipeService, IPostService postService, IUserService userService, IFavoriteService favoriteService)
        {
            _recipeService = recipeService;
            _postService = postService;
            _userService = userService;
            _favoriteService = favoriteService;
        }
        [BindProperty]
        public Recipe Recipe { get; set; } = new Recipe();
        public Post Post { get; set; }
        public Favorite Favorite { get; set; }
        public List<Post> Posts { get; set; }
        public List<User> Users { get; set; }
        public User User { get; set; }
        public IActionResult OnGet(int id)
        {
            User = GetSessionUser();
            Recipe = _recipeService.Retrieve(id);

            if (Recipe == null)
            {
                return NotFound();
            }
            Posts = _postService.RetrieveAllByRecipeId(id);
            Users = _userService.RetrieveAll();
            return Page();
        }

        public IActionResult OnPost(Post post)
        {
            User user = GetSessionUser();

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            post.UserId = user;
            _postService.Create(post);

            return Redirect("/RecipesAdmin/RetrieveAll");
        }

        public IActionResult OnPostFavorite(Favorite favorite)
        {
            User user = GetSessionUser();
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Recipe recipe = _recipeService.Retrieve(Recipe.Id);

            if (recipe == null)
            {

                return RedirectToPage("/Error");
            }


            favorite.UserId = user;
            favorite.RecipeId = recipe;

            _favoriteService.Create(favorite);

            return RedirectToPage("/RecipesAdmin/RetrieveAll");
        }



        public IActionResult OnPostRemoveFavorite(int favoriteId)
        {
            _favoriteService.RemoveFavorite(favoriteId);
            return Page();
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
