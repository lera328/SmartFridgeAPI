using SmartFridgeAPI.Models;

namespace SmartFridgeAPI.DataBaseManagement
{
    public class UsersListsManager
    {
        //Добавление продукта в список данного холодильника
        public static async void addProductToList(int fridgeId, string productName)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                int id = (from p in db.СпискиПокупокs select p.IdСпПродукта).Max()+1;
                СпискиПокупок item = new СпискиПокупок
                {
                    IdСпПродукта = id,
                    IdХолодильника = fridgeId,
                    Наименование = productName,
                    Статус = false
                };
                await db.СпискиПокупокs.AddAsync(item);
                await db.SaveChangesAsync();
            }
        }
        
        //Удаление продукта из списка данного холодильника
        public static async void deleteProductFromList(int fridgeId, string productName)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var item = (from p in db.СпискиПокупокs where p.IdХолодильника == fridgeId where p.Наименование == productName select p).FirstOrDefault();
                if(item != null)
                {
                    db.СпискиПокупокs.Remove((СпискиПокупок)item);
                    await db.SaveChangesAsync();
                }                
            }
        }
        
        //Изменение продукта
        public static async void changeProductFromList(int fridgeId, string startProductName, string productName, bool status)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var item = (from p in db.СпискиПокупокs where p.IdХолодильника == fridgeId where p.Наименование == startProductName select p).FirstOrDefault();
                if(item != null)
                {
                    item.Наименование = productName;
                    item.Статус = status;
                    await db.SaveChangesAsync();
                }                
            }
        }
    }
}
