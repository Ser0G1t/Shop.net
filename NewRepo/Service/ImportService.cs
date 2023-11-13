using NewRepo.Exceptions;
using NewRepo.IService;
using NewRepo.Strategy.ImportStrategy;

namespace NewRepo.Service
{
    public class ImportService : IImportService
    {
        private IImportStrategy _importStrategy;
        public async Task Import(string format, IFormFile file)
        {
            setStrategy(format);
            await _importStrategy.Import(file);
        }
        private void setStrategy(string format)
        {
            switch (format.ToLower())
            {
                case "xls":
                  _importStrategy = new ImportXLS();
                    break;
                case "csv":
                 _importStrategy = new ImportCSV();
                    break;
                default:
                    throw new FileFormatNotSupported("strategy doesnt exist!");
            }
        }
    }
}
