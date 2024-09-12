using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Users
{
    public class UpdateModel : PageModel
    {
        private readonly IUserService _userService;
        public UpdateModel(IUserService userService)
        {
            _userService = userService;
        }
        public User User { get; set; }
        public void OnGet(int id)
        {
            GetSessionUser();
            User = _userService.Retrieve(id);
        }
        public IActionResult OnPost(User user)
        {
            _userService.Update(user);
            return Redirect("/Users/RetrieveAll");
        }
        private void GetSessionUser()
        {
            string user = HttpContext.Session.GetString("user");

            if (user is not null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }

    }
}
