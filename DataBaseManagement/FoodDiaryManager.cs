using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.DataBaseManagement
{
    public class FoodDiaryManager
    {
        //Добавление продукта в дневник
        public static async void addProductDiary(int userId, int k, DateOnly date, int eatingId, int productId)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                int id = (from p in db.УпотребленныеПродуктыs select p.IdПродукта).Max() + 1;
                УпотребленныеПродукты product = new УпотребленныеПродукты
                {
                    IdУпотребленногоПродукта = id,
                    IdПользователя = userId,
                    IdПродукта = productId, 
                    Количество = k,
                    Дата = date,
                    IdПриемаПищи = eatingId
                };
                await db.УпотребленныеПродуктыs.AddAsync(product);
                int fridgeId = (from f in db.Пользователиs where f.IdПользователя == userId select f.IdХолодильника).FirstOrDefault();
                FridgeManager.UpdateProductCount(fridgeId, productId, k);
                await db.SaveChangesAsync();
            }
        }

        //Удаление продукта из дневника
        public static async void deleteProductFromDiary(int productId)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var item = (from p in db.УпотребленныеПродуктыs where p.IdУпотребленногоПродукта == productId select p).FirstOrDefault();
                if (item != null)
                {
                    db.УпотребленныеПродуктыs.Remove((УпотребленныеПродукты)item);
                    await db.SaveChangesAsync();
                }
            }
        }

        //Изменение количества продукта
        public static async void changeProductFromDiary(int productFDairyId, int count)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var item = (from p in db.УпотребленныеПродуктыs where p.IdУпотребленногоПродукта == productFDairyId select p).FirstOrDefault();
                if (item != null)
                {
                    item.Количество = count;
                    await db.SaveChangesAsync();
                }
            }
        }

        //Получить съеденные в этот день продукты
        public static async Task<ActionResult<List<УпотребленныеПродукты>>> GetFoodDiary(int userId, DateOnly date)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var productsList = (from p in db.УпотребленныеПродуктыs where p.IdПользователя == userId where p.Дата==date select p).ToList();
                return new ActionResult<List<УпотребленныеПродукты>>(productsList);

            }
        }
    }
}

