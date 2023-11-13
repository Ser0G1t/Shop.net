using NewRepo.Enums;

namespace NewRepo.DTO
{
    public class OrderByIdDTO
    {
        public PaymentMethod paymentMethod { get; set; }
        public ShipMethod shipMethod { get; set; }
        public OrderStatus status { get; set; }
        public DateTime createdDate { get; set; }
        public List<ProductDTO> products { get; set; }
    }
}
