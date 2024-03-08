
namespace MercadoLibre.Models
{
    public class Menu
    {
        public string Name { get; set; } = string.Empty;
        public bool IsSeparator { get; set; }
        public bool ShowInfo => !IsSeparator;
        public string NavigateTo { get; set; } = string.Empty;
    }
}
