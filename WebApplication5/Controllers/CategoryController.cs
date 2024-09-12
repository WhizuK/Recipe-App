using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            return _service.Create(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public Category Put([FromBody] Category category)
        {
            return _service.Update(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
