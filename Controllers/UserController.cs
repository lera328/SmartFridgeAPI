using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.DataBaseManagement;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        //при наличии такого пользоваетля возвращает его id, иначе 0 (авторизация)
        [HttpGet, ActionName("ValidUser")]
        public Task<int> ValidUser(string email, string pass)
        {
            return UsersManager.validUserFromEmail(email, pass);
        }

        //регистрация нового пользователя
        [HttpPost, ActionName("PostUser")]
        public async Task<ActionResult<Пользователи>> PostUser(string email, string pass, string? code)
        {
            UsersManager.addNewUser(email, pass, code);
            return Ok();
        }       
    }
}
