using NewRepo.Entity;

namespace NewRepo.IService
{
    public interface IOrderService : ICoreService<Order>
    {
       Task<ICollection<Order>> getOrdersByUser();
    }
}
