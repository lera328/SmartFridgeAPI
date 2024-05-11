using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.DataBaseManagement;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RecipesController : Controller
    {
        [HttpGet, ActionName("GetAllRecipes")]
        public Task<ActionResult<List<Рецепты>>> GetRecipes()
        {
            return RecipesManager.GetRecipes();
        }

        // POST api/users
        [HttpPost, ActionName("PostRecipe")]
        public async Task<ActionResult<УпотребленныеПродукты>> PostRecipe(
            int userId, string name, string description, List<НаборыПродуктов> products)
        {
            RecipesManager.addRecipe(userId, name, description, products);
            return Ok();
        }


        //Удаление продукта  из холодильника
        [HttpDelete, ActionName("DeleteRecipe")]
        public IActionResult DeleteRecipe(int userId, string name)
        {
            RecipesManager.deleteRecipe(userId, name);
            return NoContent();
        }

        // PUT api/users/
        [HttpPut, ActionName("UpdateRecipe")]
        public IActionResult UpdateRecipe(
            int userId, string name, string description, List<НаборыПродуктов> products)
        {
            RecipesManager.changeRecipe(userId, name, description, products);
            return Ok();
        }
    }
}
