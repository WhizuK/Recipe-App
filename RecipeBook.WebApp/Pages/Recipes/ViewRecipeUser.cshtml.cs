using Livro_de_Receita.modelo;
using Livro_de_Receita.service.implemetations;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Recipes
{
    public class ViewRecipeUserModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        IFavoriteService _favoriteService;
        public ViewRecipeUserModel(IRecipeService recipeService, IPostService postService, IUserService userService, IFavoriteService favoriteService)
        {
            _recipeService = recipeService;
            _postService = postService;
            _userService = userService;
            _favoriteService = favoriteService;
        }
        [BindProperty]
        public Recipe Recipe { get; set; } = new Recipe();
        public Post Post { get; set; }
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

            return Redirect("/Recipes/RetrieveAll");
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

            return RedirectToPage("/Recipes/RetrieveAll");
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
