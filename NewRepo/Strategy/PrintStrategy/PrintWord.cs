using NewRepo.Entity;


namespace NewRepo.Strategy.PrintStrategy
{
    class PrintWord : IPrintStrategy
    {
        public void Print(Invoice invoice)
        {
            Console.WriteLine("word");
        }
    }
}
