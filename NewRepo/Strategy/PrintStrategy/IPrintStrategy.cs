using NewRepo.Entity;

namespace NewRepo.Strategy.PrintStrategy
{
    public interface IPrintStrategy
    {
        void Print(Invoice invoice);
    }
}
