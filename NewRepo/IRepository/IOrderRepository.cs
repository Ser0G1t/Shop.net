using NewRepo.Entity;

namespace NewRepo.IRepository
{
    public interface IOrderRepository : ICoreRepository<Order>
    {
        Task<ICollection<Order>> getOrdersByUser();
    }
}
