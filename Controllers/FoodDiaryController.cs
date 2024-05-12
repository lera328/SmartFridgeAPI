using FatSecretDotNet.ResponseObjects;
using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.DataBaseManagement;
using SmartFridgeAPI.FatSecretApi;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FoodDiaryController : Controller
    {
        [HttpGet, ActionName("GetDiary")]
        public Task<ActionResult<List<УпотребленныеПродукты>>> GetDiary(int userId, DateOnly date)
        {
            return FoodDiaryManager.GetFoodDiary(userId, date);
        }
        
        [HttpGet, ActionName("TEST")]
        public FoodsSearchResponse GetTEST()
        {
            return Test.get();
        }

        // POST api/users
        [HttpPost, ActionName("PostProductToDiary")]
        public async Task<ActionResult<УпотребленныеПродукты>> PostProduct(int userId, int k, DateOnly date, int eatingId, int productId)
        {
            FoodDiaryManager.addProductDiary(userId, k, date, eatingId, productId);
            return Ok();
        }


        //Удаление продукта  из холодильника
        [HttpDelete, ActionName("DeleteProductFromDiary")]
        public IActionResult DeleteProduct(int productId)
        {
            FoodDiaryManager.deleteProductFromDiary(productId);
            return NoContent();
        }

        // PUT api/users/
        [HttpPut, ActionName("UpdateProduct")]
        public IActionResult UpdateProductInDiary(int productFDairyId, int count)
        {
            FoodDiaryManager.changeProductFromDiary(productFDairyId, count);
            return Ok();
        }
    }
}
