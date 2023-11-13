using NewRepo.Context;
using NewRepo.Entity;
using NewRepo.IRepository;

namespace NewRepo.Repository
{
    class InvoiceRepository : CoreRepository<Invoice>, IInvoiceCrudRepository
    {
        public InvoiceRepository(CoreContext context) : base(context)
        {
          
        }
    }
}
