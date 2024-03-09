
namespace MercadoLibre.Models
{
    public class Menu
    {
        public string Name { get; set; } = string.Empty;
        public string IconSource { get; set; } = string.Empty;
        public bool IsSeparator { get; set; }
        public bool ShowIcon => !IsSeparator && !string.IsNullOrEmpty(IconSource);
        public bool ShowOnlyText => !ShowIcon;
        public string NavigateTo { get; set; } = string.Empty;
    }
}
