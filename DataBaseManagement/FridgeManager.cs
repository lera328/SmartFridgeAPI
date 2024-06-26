﻿using Microsoft.AspNetCore.Mvc;
using SmartFridgeAPI.Models;
using SmartFridgeAPI.ProverkaCheka;

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
        
        public static async void UpdateProductCount(int fridgeId, int productId, int остаток)
        {
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                var product = (from p in db.ПродуктыВХолодильникеs
                               where p.IdПродукта == productId
                               select p).FirstOrDefault();
                if (product != null )
                {
                    if(product.Остаток!=null)
                         product.Остаток -= остаток;
                  
                }
                await db.SaveChangesAsync();

            }
        }

        //Добавление продуктов сканированием чека
        public static async void AddProductFromRecipeToFridge(int fridgeId, string qr)
        {
            
            Receipt receipt = await GetReciept(qr);
            List<Product> products = receipt.Goods;
            using (SmartFridgeContext db = new SmartFridgeContext())
            {
                foreach (Product pr in products)
                {
                    int id = (from p in db.ПродуктыВХолодильникеs select p.IdПродукта).Max() + 1;
                    ПродуктыВХолодильнике product = new ПродуктыВХолодильнике
                    {
                        IdПродукта = id,
                        IdХолодильника = fridgeId,
                        Наименование = pr.Name,
                        ДатаДобавления = DateOnly.FromDateTime(DateTime.Now),
                        СрокГодности = expirationDate

                    };
                    db.ПродуктыВХолодильникеs.Add(product);
                    await db.SaveChangesAsync();
                }
                
            }
        }
        private static async Task<Receipt> GetReciept(string qrRaw)
        {
            Proverkacheka p = new Proverkacheka();
            return await p.GetAsyncByRaw(qrRaw);
        }

    }
}
