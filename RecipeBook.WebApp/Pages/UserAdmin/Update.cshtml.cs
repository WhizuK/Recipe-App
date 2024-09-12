using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.UserAdmin
{
    public class UpdateModel : PageModel
    {
        private readonly IUserService _userService;
        public UpdateModel(IUserService userService)
        {
            _userService = userService;
        }
        public User User { get; set; }
        public IActionResult OnGet(int id)
        {

            User = _userService.Retrieve(id);
            return Page();
        }
        public IActionResult OnPost(User user)
        {
            _userService.Update(user);
            return Redirect("/Admin/Admin");
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
