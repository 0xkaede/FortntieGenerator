using FortniteGenerator.FortniteApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteGenerator.Util
{
    public class FortniteAPI
    {
        public static class Endpoints
        {
            public static Uri BaseV2 = new Uri("https://fortnite-api.com/v2/");
            public static Uri BaseV1 = new Uri("https://fortnite-api.com/v1/");

            public static Uri Cosmetics = new Uri(BaseV2, "cosmetics/br");
            public static Uri CosmeticsByType(string type) => new Uri(BaseV2, $"cosmetics/br/search/all?backendType={type}");
            public static Uri MultipleCosmeticsById(params string[] cosmeticIds) => new Uri(BaseV2, "cosmetics/br/search/ids?id=" + string.Join("&id=", cosmeticIds));
            public static Uri CosmeticByName(string cosmeticId) => new Uri(BaseV2, $"cosmetics/br/search?name={cosmeticId}");


            public static Uri AES = new Uri(BaseV2, "aes");
        }

        private static async Task<T> GetData<T>(Uri endpoint)
            => JsonConvert.DeserializeObject<FortniteAPIResponse<T>>(await new HttpClient().GetStringAsync(endpoint)).Data;

        public static async Task<List<Cosmetic>> GetCosmetics()
            => await GetData<List<Cosmetic>>(Endpoints.Cosmetics);

        public static async Task<List<Cosmetic>> GetCosmeticsByType(string type)
            => await GetData<List<Cosmetic>>(Endpoints.CosmeticsByType(type));

        public static async Task<List<Cosmetic>> GetCosmeticsById(params string[] cosmeticIds)
            => await GetData<List<Cosmetic>>(Endpoints.MultipleCosmeticsById(cosmeticIds));

        public static async Task<Cosmetic> GetCosmeticByName(string cosmeticName)
            => await GetData<Cosmetic>(Endpoints.CosmeticByName(cosmeticName));

        public static async Task<AES> GetAESKeys()
            => await GetData<AES>(Endpoints.AES);

    }
}
