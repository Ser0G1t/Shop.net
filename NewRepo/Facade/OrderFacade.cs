using Microsoft.EntityFrameworkCore;
using NewRepo.Context;
using NewRepo.Entity;
using NewRepo.Enums;
using NewRepo.Exceptions;

namespace NewRepo.Facade
{
    public class OrderFacade : IOrderFacade
    {
        private readonly CoreContext _coreContext;
        private readonly static double VAT = 0.23;

        public OrderFacade(CoreContext context)
        {
            _coreContext = context;
        }
        public async Task finalizeOrder(Order order)
        {
            statusValidator(order);
            double gross = calculateGrossPrice(order);
            double net = calculateNetPrice(gross);
            try{
                var invoice = new Invoice(net, gross, order);
                order.status = OrderStatus.CLOSED;
                order.fullPrice = gross;
                order.Invoice = invoice;
                _coreContext.invoice.Add(invoice);
                _coreContext.order.Entry(order).State = EntityState.Modified;
                await _coreContext.SaveChangesAsync();
            }
            catch (FinalizeOrderException ex){
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex){
                Console.WriteLine(ex.InnerException);
            }
        }

        public async Task addProduct(long orderId, long productId)
        {
            var order = _coreContext.order.Find(orderId);
            var product = _coreContext.products.Find(productId);
            if (order is null || product is null) {
                throw new EntityNotFound("resource can't be found");
            }
            statusValidator(order);
            order.products.Add(product);
            await _coreContext.SaveChangesAsync();
        }

        private double calculateGrossPrice(Order order)
        {
            return order.products.Sum(p => p.price);
        }
        private double calculateNetPrice(double price)
        {
            double toSubract = price * VAT;
            return price - toSubract;
        }
        private void statusValidator(Order order)
        {
            if (order.status == OrderStatus.CLOSED)
            {
                throw new OrderImpossibleToUpdate("order already has been processed");
            }
        }

    }
}
