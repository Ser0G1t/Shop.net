using NewRepo.Entity;
using NewRepo.Exceptions;
using NewRepo.IService;
using NewRepo.Strategy.PrintStrategy;

namespace NewRepo.Service
{
    class PrintService : IPrintService
    {
        private IPrintStrategy _printStrategy;
        public void Print(string format, Invoice invoice)
        {
            setStrategy(format);
            _printStrategy.Print(invoice);
        }

        private void setStrategy(string format)
        {
            switch (format.ToLower())
            {
                case "pdf":
                    _printStrategy = new PrintPDF();
                    break;
                case "word":
                    _printStrategy = new PrintWord();
                    break;
                default:
                    throw new FileFormatNotSupported("strategy doesnt exist!");
            }
        }
    }
}
