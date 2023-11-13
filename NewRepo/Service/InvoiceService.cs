using NewRepo.Entity;
using NewRepo.IRepository;
using NewRepo.IService;

namespace NewRepo.Service
{
    class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceCrudRepository _invoiceRepository;
        public InvoiceService(IInvoiceCrudRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<Invoice> GetById(long productId)
        {
            return await _invoiceRepository.GetById(productId);
        }
        public async Task Insert(Invoice product)
        {
            await _invoiceRepository.Insert(product);
        }
        public async Task Update(long productId, Invoice product)
        {
            await _invoiceRepository.Update(productId, product);
        }
        public async Task Delete(long id)
        {
            await _invoiceRepository.Delete(id);
        }
        public async Task<IEnumerable<Invoice>> GetAll()
        {
            return await _invoiceRepository.GetAll();
        }
    }
}
