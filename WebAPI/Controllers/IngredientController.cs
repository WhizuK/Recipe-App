﻿using Livro_de_Receita.modelo;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientsService _service;
        public IngredientController (IIngredientsService service)
        {
            _service = service;
        }
        // GET: api/<IngredientController>
        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            return _service.RetrieveAll();
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public Ingredient Get(int id)
        {
            return _service.Retrieve(id);
        }

        // POST api/<IngredientController>
        [HttpPost]
        public Ingredient Post([FromBody] Ingredient ingredient)
        {
            return _service.Create(ingredient);
        }

        // PUT api/<IngredientController>/5
        [HttpPut]
        public Ingredient Put(int id, [FromBody] Ingredient ingredient)
        {
            return _service.Update(ingredient);
        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
