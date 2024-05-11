using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.DataBaseManagement;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FridgeController : ControllerBase
    {

        [HttpGet, ActionName("GetProducts")]
        public Task<ActionResult<List<���������������������>>> GetProduct(int fridgeId)
        {
            return FridgeManager.GetProductsFromFridge(fridgeId);
        }

        // POST api/users
        [HttpPost, ActionName("PostProduct")]
        public async Task<ActionResult<���������������������>> PostProduct(int fridgeId, string name)
        {
            FridgeManager.AddProductToFridge(fridgeId, name);
            return Ok();
        }
       

        //�������� ��������  �� ������������
        [HttpDelete, ActionName("DeleteProduct")]
        public IActionResult DeleteProduct(int frigeId, string productName)
        {
            FridgeManager.deleteProduct(frigeId, productName);
            return NoContent();
        }

        // PUT api/users/
        [HttpPut, ActionName("UpdateProduct")]
        public IActionResult UpdateProduct(int fridgeId, string startName, string name, int? id_�������, int? �������, int ������������)
        {
            FridgeManager.UpdateProduct(fridgeId, startName, name, id_�������, �������, ������������);
            return Ok();
        }
    }
}
