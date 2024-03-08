
using Newtonsoft.Json;

namespace MercadoLibre.Utils
{
    internal static class Utils
    {
        public static async Task<T> ReadJson<T>(string JsonName)
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync($"{JsonName}.json");
                using var reader = new StreamReader(stream);

                var JsonFile = reader.ReadToEnd();

                var Obj = JsonConvert.DeserializeObject<T>(JsonFile)!;
                return Obj;
            } catch
            {
                return Activator.CreateInstance<T>();
            }
        }
    }
}
