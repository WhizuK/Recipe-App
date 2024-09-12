// UpdateUserModel.cs

using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

public class UpdateUserModel : PageModel
{
    private readonly IUserService _userService;

    public UpdateUserModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    public User User { get; set; }

    public IActionResult OnGet()
    {
        User = GetSessionUser();
        return Page();
    }

    public IActionResult OnPost()
    {
        User sessionUser = GetSessionUser();
        if (sessionUser != null)
        {
            sessionUser.Name = User.Name;
            sessionUser.Email = User.Email;
        }
        _userService.Update(sessionUser);
        SetSessionUser(sessionUser);

        return Redirect("/Users/ViewUser");
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
    private void SetSessionUser(User user)
    {
        string jsonString = JsonSerializer.Serialize(user);
        HttpContext.Session.SetString("user", jsonString);
    }
}
