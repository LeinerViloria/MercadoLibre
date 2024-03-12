
namespace MercadoLibre.Models
{
    public class PurchaseItem
    {
        public string ImageSource { get; set; }
        public string SellDate { get; set; }
        public PurchaseState State { get; set; }
        public string? ArrivedDate { get; set; }

    }

    public enum PurchaseState
    {
        Pendiente = 0,
        Entregado = 1,
    }
}
