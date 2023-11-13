using Microsoft.EntityFrameworkCore;
using NewRepo.Context;
using NewRepo.Entity;
using NewRepo.Exceptions;
using NewRepo.IRepository;

namespace NewRepo.Repository
{
    class OrderRepository : CoreRepository<Order>, IOrderRepository
    {
        public OrderRepository(CoreContext context) :base(context)
        {
            
        }
        public async Task<ICollection<Order>> getOrdersByUser()
        {
            throw new NotImplementedException();
        }
        public async override Task<Order> GetById(long id)
        {
            var order= await _context.order.Include(order => order.products).FirstOrDefaultAsync(el => el.OrderId == id);
            if (order is null)
            {
                throw new EntityNotFound($"{id} not found");
            }
            return order;
        }
    }
}
