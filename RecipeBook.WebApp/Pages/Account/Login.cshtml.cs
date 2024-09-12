using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;
using System.Text.Json;

namespace RecipeBook.WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _service;

        public LoginModel(IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            User user = _service.Login(username, password);

            if (user != null)
            {
                string jsonString = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("user", jsonString);

                if (user.Admin)
                {
                    return RedirectToPage("/Admin/Admin");
                }
                else if (user.Blocked)
                {
                    return RedirectToPage("/Blocked");
                }
                else
                {
                    return RedirectToPage("/UserPage/MainPageUser");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciais inválidas.");
                return Page();
            }
        }


    }
}
