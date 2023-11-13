using NewRepo.Entity;

namespace NewRepo.Facade
{
    public interface IOrderFacade
    {
        Task finalizeOrder(Order order);
        Task addProduct(long orderId, long productId);
    }
}
