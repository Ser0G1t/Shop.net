using NewRepo.Entity;
using NewRepo.Enums;
using NewRepo.Exceptions;
using NewRepo.IRepository;
using NewRepo.IService;

namespace NewRepo.Service
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> GetById(long orderId)
        {
            return await _orderRepository.GetById(orderId);
        }
        public async Task Insert(Order order)
        {
            await _orderRepository.Insert(order);
        }
        public async Task Update(long orderId, Order order)
        {
            if (order.status == OrderStatus.CLOSED)
            {
                throw new OrderImpossibleToUpdate("order already has been processed");
            }
            await _orderRepository.Update(orderId, order);
        }
        public async Task Delete(long orderId)
        {
            await _orderRepository.Delete(orderId);
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }
        public async Task<ICollection<Order>> getOrdersByUser()
        {
            throw new NotImplementedException();
        }
    }
}
