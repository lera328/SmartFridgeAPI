using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.DataBaseManagement
{
    public class FridgeManager
    {
        //Срок хранения для всех продуктов
        public static int expirationDate = 7;
        //Добавление одного продукта в холодильник
        public static async Task<ActionResult<ПродуктыВХолодильнике>> AddProductToFridge(int fridgeId, string name)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                int id = (from p in db.ПродуктыВХолодильникеs select p.IdПродукта).Max() + 1;
                ПродуктыВХолодильнике product = new ПродуктыВХолодильнике
                {
                    IdПродукта = id,
                    IdХолодильника = fridgeId,
                    Наименование = name,
                    ДатаДобавления = DateOnly.FromDateTime(DateTime.Now),
                    СрокГодности = expirationDate

                };
                db.ПродуктыВХолодильникеs.Add(product);
                await db.SaveChangesAsync();
                return new ActionResult<ПродуктыВХолодильнике>(product);

            }
        }

        //получить все продукты холодильника
        public static async Task<ActionResult<List<ПродуктыВХолодильнике>>> GetProductsFromFridge(int fridgeId)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var productsList = (from p in db.ПродуктыВХолодильникеs where p.IdХолодильника == fridgeId select p).ToList();
                return new ActionResult<List<ПродуктыВХолодильнике>>(productsList);

            }
        }

        public static async void deleteProduct(int fridgeId, string productName)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var product = (from p in db.ПродуктыВХолодильникеs
                               where p.IdХолодильника ==
                               fridgeId
                               where p.Наименование == productName
                               select p).FirstOrDefault();
                if (product != null)
                    db.ПродуктыВХолодильникеs.Remove(product);
                await db.SaveChangesAsync();
            }
        }

        public static async void UpdateProduct(int fridgeId, string startName, string name, int? id_единицы, int? остаток, int срокГодности)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var product = (from p in db.ПродуктыВХолодильникеs
                               where p.IdХолодильника ==
                                   fridgeId
                               where p.Наименование == startName
                               select p).FirstOrDefault();
                if (product != null)
                {
                    product.Наименование = name;
                    product.IdЕдиницы = id_единицы;
                    product.Остаток = остаток;
                    product.СрокГодности = срокГодности;
                }
                await db.SaveChangesAsync();

            }
        }

    }
}
