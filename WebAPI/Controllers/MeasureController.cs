using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasuresService _service;
        public MeasureController(IMeasuresService service)
        {
            _service = service;
        }
        // GET: api/<MeasureController>
        [HttpGet]
        public IEnumerable<Measures> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<MeasureController>/5
        [HttpGet("{id}")]
        public Measures Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<MeasureController>
        [HttpPost]
        public Measures Post([FromBody] Measures measures)
        {
            return _service.Create(measures);
        }

        // PUT api/<MeasureController>/5
        [HttpPut]
        public Measures Put(int id, [FromBody] Measures measures)
        {
            return _service.Update(measures);
        }

        // DELETE api/<MeasureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
