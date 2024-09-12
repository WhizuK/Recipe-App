using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.UnRegisted
{
    public class ViewRecipeModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        public ViewRecipeModel(IRecipeService recipeService, IPostService postService, IUserService userService)
        {
            _recipeService = recipeService;
            _postService = postService;
            _userService = userService;
        }

        public Recipe Recipe { get; set; }
        public Post Post { get; set; }
        public List<Post> Posts = new List<Post>();
        public List<User> Users = new List<User>();
        public User User { get; set; }

        public IActionResult OnGet(int id)
        {

            Recipe = _recipeService.Retrieve(id);

            if (Recipe == null)
            {
                return NotFound();
            }

            Posts = _postService.RetrieveAllByRecipeId(id);

            return Page();
        }

        
    }
}
