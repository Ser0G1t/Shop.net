using NewRepo.Entity;

namespace NewRepo.IService
{
    public interface IPrintService
    {
        void Print(string format, Invoice invoice);
    }
}
