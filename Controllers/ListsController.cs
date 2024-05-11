using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.DataBaseManagement;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ListsController : Controller
    {
        // Добавление продукта в список
        [HttpPost, ActionName("PostProductToList")]
        public async Task<ActionResult<СпискиПокупок>> PostProductToList(int fridgeId, string productName)
        {
            UsersListsManager.addProductToList(fridgeId, productName);
            return Ok();
        }

        //Удаление продукта  из списка
        [HttpDelete, ActionName("DeleteProductFromList")]
        public IActionResult DeleteProductFromList(int fridgeId, string productName)
        {
            UsersListsManager.deleteProductFromList(fridgeId, productName);
            return NoContent();
        }

        //Обновление информации о продукте
        [HttpPut, ActionName("UpdateProductFromList")]
        public IActionResult UpdateProductFromList(int fridgeId, string startProductName, string productName, bool status)
        {
            UsersListsManager.changeProductFromList(fridgeId, startProductName, productName, status);
            return Ok();
        }

        //Получение списка покупок
        [HttpGet, ActionName("GetProductsFromList")]
        public Task<ActionResult<List<СпискиПокупок>>> GetProduct(int fridgeId)
        {
            return UsersListsManager.GetProductsFromFridge(fridgeId);
        }
    }
}
