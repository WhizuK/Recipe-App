using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Repositories;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeIgredientsService _recipeIgredientsService;
        public RecipeIngredientController(IRecipeIgredientsService service)
        {
            _recipeIgredientsService = service;
        }
        // GET: api/<RecipeIngredientController>
        [HttpGet("recipe/{recipeId}")]
        public IEnumerable<RecipeIngredients> Get(int recipeId)
        {
            return _recipeIgredientsService.RetrieveAll(recipeId);
        }

        // POST api/<RecipeIngredientController>
        [HttpPost]
        public RecipeIngredients Post([FromBody] RecipeIngredients recipeIngredients)
        {
            return _recipeIgredientsService.Create(recipeIngredients);
        }

    }
}
