
namespace MercadoLibre.Models
{
    public class ProductItem
    {
        public string Image {get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
        public int Price {get; set;}
        public float DiscountPercentage {get; set;}
        public float OfferPrice => Price <= 0 ?
            0 : Price - (Price/100*DiscountPercentage);
    }
}