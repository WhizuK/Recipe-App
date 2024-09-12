using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _service;
        public LoginController (IUserService service)
        {
            _service = service;
        }

        // POST api/<LoginController>
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _service.Login(user.Name, user.Password);
        }

    }
}
