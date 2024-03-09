
namespace MercadoLibre.Models
{
    public class Menu
    {
        public string Name { get; set; } = string.Empty;
        public string IconSource { get; set; } = string.Empty;
        public bool IsSeparator { get; set; }
        public bool ShowInfo => !IsSeparator;
        public bool ShowIcon => ShowInfo && !string.IsNullOrEmpty(IconSource);
        public string NavigateTo { get; set; } = string.Empty;
    }
}
