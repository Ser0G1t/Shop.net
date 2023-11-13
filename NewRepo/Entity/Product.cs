using NewRepo.Enums;
using System.Text.Json.Serialization;

namespace NewRepo.Entity
{
    public class Product
    {
        public long ProductId { get; set; }
        public string? productName { get; set; }
        public string? productDescription { get; set; }
        public ProductCategory category { get; set; }
        public double price { get; set; }
        [JsonIgnore]
        public List<Order> orders { get; set; }
        public DateTime createdDate { get; set; }
        public Product()
        {
            createdDate = DateTime.Now;
            this.orders = new List<Order>();
        }
        public Product(string productName, string? productDescription, ProductCategory category, double price)
        {
            this.productName = productName;
            this.productDescription = productDescription;
            this.category = category;
            this.price = price;
            this.orders = new List<Order>();
            createdDate = DateTime.Now;
        }
    }
}
