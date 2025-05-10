using System.ComponentModel.DataAnnotations;

namespace BuyWise.Models.Products
{
    //public record ProductStock(long productId, float Qty);

    public class Product : BaseModel
    {


        public Product()
        {
            //List<ProductStock> productQty = new();

            //ProductStock p1 = new(2, 0);
            //productQty.Add(p1);
            //ProductStock p2 = new(3, 10);
            //productQty.Add(p2);
            //ProductStock p3 = new(4, 12);
            //productQty.Add(p1);
            //ProductStock p4 = new(5, 0);
            //productQty.Add(p2);
        }
        public string? ShortDescription { get; set; }
        public string? ArabicName { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "*")]
        public required decimal CurrentPrice { get; set; }
        public long CategoryId { get; set; }
        public Category? Category { get; set; }
        public long BrandId { get; set; }
        public Brand? Brand { get; set; }
        public IEnumerable<ProductImage>? ProductImages { get; set; }
        //public long Rate { get; set; }

        //public List<ProductStock>? ProductStocks { get; set; }

    }









}
