using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.DataBaseManagement
{
    public class RecipesManager
    {
        //Добавление рецепта (в списке ингредиентов idрецепта и idпродукта при передаче его в метод задаются произвольно)
        public static async void addRecipe(int userId, string name, string description, List<НаборыПродуктов> products)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                int id = (from r in db.Рецептыs select r.IdРецепта).Max() + 1;
                Рецепты reciepe = new Рецепты
                {
                    IdРецепта = id,
                    Наименование = name,
                    ПоследовательностьДействий = description,
                    IdПользователя = userId
                };
                await db.Рецептыs.AddAsync(reciepe);
                foreach (var item in products)
                {
                    item.IdРецепта = id;
                    int pId=(from p in db.НаборыПродуктовs select p.IdПродукта).Max() + 1;
                    item.IdПродукта = pId;
                    await db.НаборыПродуктовs.AddAsync(item);
                }
                await db.SaveChangesAsync();
            }
        }

        //Удаление рецепта
        public static async void deleteRecipe(int userId, string name)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var item = (from p in db.Рецептыs where p.IdПользователя == userId where p.Наименование==name select p).FirstOrDefault();
                var productsList = (from pr in db.НаборыПродуктовs where pr.IdРецепта == item.IdРецепта select pr).ToList();
                if (item != null)
                {
                    db.Рецептыs.Remove((Рецепты)item);
                    await db.SaveChangesAsync();
                }
                if (productsList != null)
                {
                    foreach(var product in productsList)
                    {
                        db.НаборыПродуктовs.Remove(product);
                    }
                }
                
                await db.SaveChangesAsync();
            }
        }

        //Изменение рецепта
        public static async void changeRecipe(int userId, string name, string description, List<НаборыПродуктов> products)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var item = (from p in db.Рецептыs where p.IdПользователя == userId where p.Наименование == name select p).FirstOrDefault();
                var productsList = (from pr in db.НаборыПродуктовs where pr.IdРецепта == item.IdРецепта select pr).ToList();
                if (item != null)
                {
                    db.Рецептыs.Remove((Рецепты)item);
                    await db.SaveChangesAsync();
                }
                if (productsList != null)
                {
                    foreach (var product in productsList)
                    {
                        db.НаборыПродуктовs.Remove(product);
                    }
                }

                await db.SaveChangesAsync();

                Рецепты reciepe = new Рецепты
                {
                    IdРецепта = item.IdРецепта,
                    Наименование = name,
                    ПоследовательностьДействий = description,
                    IdПользователя = userId
                };
                await db.Рецептыs.AddAsync(reciepe);
                foreach (var it in products)
                {
                    it.IdРецепта = item.IdРецепта;
                    int pId = (from p in db.НаборыПродуктовs select p.IdПродукта).Max() + 1;
                    it.IdПродукта = pId;
                    await db.НаборыПродуктовs.AddAsync(it);
                }
                await db.SaveChangesAsync();

            }
        }

        //Получить рецепты все
        public static async Task<ActionResult<List<Рецепты>>> GetRecipes()
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var recipeList = (from p in db.Рецептыs select p).ToList();
                return new ActionResult<List<Рецепты>>(recipeList);
            }
        }
    }
}
