using FatSecretDotNet.Authentication;
using FatSecretDotNet;
using FatSecretDotNet.RequestObjects;
using FatSecretDotNet.ResponseObjects;

namespace SmartFridgeAPI.FatSecretApi
{
    public class Test
    {
        public static FoodsSearchResponse get() 
        { 
            FatSecretCredentials credentials = new FatSecretCredentials()
            {
                ClientId = "b0a702ea56d04ceaacec1c26a1518ec0",
                ClientSecret = "f7d93f237c9d417a9504e5e7e9c35c36",
                Scope = "basic" // basic or premier
            };

            FatSecretClient client = new FatSecretClient(credentials);
            FoodsSearchRequest foodSearchRequest = new FoodsSearchRequest()
            {
                SearchExpression = "ДОМИК В ДЕРЕВНЕ Сметана 15% 300г п",
                MaxResults = 25, //optional
                PageNumber = 1   //optional
            };
            var foods = client.FoodsSearchAsync(foodSearchRequest);
            return foods.Result;
        }
    }
}
