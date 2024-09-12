using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        // GET: api/<FavoriteController>
        [HttpGet]
        public IEnumerable<Favorite> Get()
        {
            return _favoriteService.RetrieveAll();
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public Favorite Get(int id)
        {
            return _favoriteService.Retrieve(id);
        }

        // POST api/<FavoriteController>
        [HttpPost]
        public Favorite Post([FromBody] Favorite favorite)
        {
            return _favoriteService.Create(favorite);
        }

        // PUT api/<FavoriteController>/5
        [HttpPut]
        public Favorite Put(int id, [FromBody] Favorite favorite)
        {
            return _favoriteService.Update(favorite);
        }

        // DELETE api/<FavoriteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _favoriteService.Delete(id);
        }
    }
}
