using NewRepo.Enums;

namespace NewRepo.Entity
{
    public class Order
    {
        public long OrderId { get; set; }
        public Invoice? Invoice { get; set; }
        public long? InvoiceId {  get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public ShipMethod shipMethod { get; set; }
        public OrderStatus status { get; set; }
        public double fullPrice { get; set; }
        public DateTime createdDate { get; set; }
        public List<Product> products { get; set; }
        public Order()
        {
            products = new List<Product>();
            status = OrderStatus.OPEN;
            createdDate = DateTime.Now;
        }
    }
}
