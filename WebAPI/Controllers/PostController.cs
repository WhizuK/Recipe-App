using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService service)
        {
            _postService = service;
        }

        // GET: api/<PostController>
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _postService.RetrieveAll();
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _postService.Retrieve(id);
        }

        // POST api/<PostController>
        [HttpPost]
        public Post Post([FromBody] Post post)
        {
            return _postService.Create(post);
        }

        // PUT api/<PostController>/5
        [HttpPut]
        public Post Put(int id, [FromBody] Post post)
        {
            return _postService.Update(post);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _postService.Delete(id);
        }
    }
}
