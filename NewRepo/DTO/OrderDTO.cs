using NewRepo.Enums;
using System.ComponentModel.DataAnnotations;

namespace NewRepo.DTO
{
    public class OrderDTO
    {
        [Required(ErrorMessage = "paymentMethod is required!")]
        public PaymentMethod paymentMethod { get; set; }
        [Required(ErrorMessage = "shipMethod is required!")]
        public ShipMethod shipMethod { get; set; }
    }
}
