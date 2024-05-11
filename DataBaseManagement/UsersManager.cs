using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.DataBaseManagement
{
    public class UsersManager
    {
        //создание нового холодильника
        private static async Task<int> addFridgeAsync()
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                int id = (from f in db.Холодильникиs select f.IdХолодильника).Max() + 1;
                Холодильники fridge = new Холодильники
                {
                    IdХолодильника = id,
                    КодДоступа = GenerateRandomCode()
                };
                db.Холодильникиs.Add(fridge);
                await db.SaveChangesAsync();
                return id;
            }
        }

        //регистрация нового пользователя
        //нужно проверить нет ли в базе такого email
        public static async void addNewUser(string email, string pass, string? fridgeCode)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                int? fId = null;
                if (fridgeCode != null)
                    fId = await (from f in db.Холодильникиs where f.КодДоступа == fridgeCode select f.IdХолодильника).FirstOrDefaultAsync();
                if (fId == null)
                    fId = addFridgeAsync().Result;

                int id = (from p in db.Пользователиs select p.IdПользователя).Max() + 1;
                Пользователи user = new Пользователи
                {
                    IdПользователя = id,
                    Email = email,
                    Пароль = pass,
                    IdХолодильника = (int)fId
                };

                await db.Пользователиs.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }

        private static string GenerateRandomCode()
        {
            int length = 8;
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            char[] code = new char[length];
            for (int i = 0; i < length; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }
            return new string(code);
        }

        //Получение пользователя(вход)
        public static Пользователи getUserFromEmail(string email)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var user = (from u in db.Пользователиs where u.Email == email select u).FirstOrDefault();
                return user;
            }
        }

        //если пользователь с таким паролем существует, то возвращает его id, иначе 0
        public static async Task<int> validUserFromEmail(string email, string pass)
        {
            Пользователи user = getUserFromEmail(email);
            if (user != null)
            {
                if (user.Пароль == pass) return user.IdПользователя;
            }
            return 0;
        }



    }
}
