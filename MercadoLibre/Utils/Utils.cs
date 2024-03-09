
using MercadoLibre.Models;
using MercadoLibre.Pages;
using Newtonsoft.Json;

namespace MercadoLibre.Utils
{
    internal static class Utils
    {
        /*
         * <summary>
         * 
         * <summary>
         */
        public static async Task<T> ReadJson<T>(string JsonName)
        {
            try
            {
                using var Stream = await FileSystem.OpenAppPackageFileAsync($"{JsonName}.json");
                using var Reader = new StreamReader(Stream);

                var JsonFile = Reader.ReadToEnd();

                var Obj = JsonConvert.DeserializeObject<T>(JsonFile)!;
                return Obj;
            } catch
            {
                return Activator.CreateInstance<T>();
            }
        }

        public static Type? SearchType(string Name)
        {
            var Result = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.GetType(Name) is not null)
                .Select(x => x.GetType(Name))
                .FirstOrDefault();

            return Result;
        }

        public static ContentPage GetContentPage(string PageName)
        {
            if (string.IsNullOrEmpty(PageName))
                return Activator.CreateInstance<ViewUnderDevelopment>();

            var PagesNamespace = typeof(Home).Namespace;

            var ViewType = SearchType($"{PagesNamespace}.{PageName}");

            if (ViewType is null)
                return Activator.CreateInstance<ViewUnderDevelopment>();

            return (ContentPage) Activator.CreateInstance(ViewType)!;
        }
    }
}
