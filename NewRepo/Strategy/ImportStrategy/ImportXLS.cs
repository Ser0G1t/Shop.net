using NewRepo.Entity;
using OfficeOpenXml;
using NewRepo.Context;
using NewRepo.Enums;

namespace NewRepo.Strategy.ImportStrategy
{
    class ImportXLS : IImportStrategy
    {
        private readonly CoreContext _coreContext;
        public ImportXLS()
        {
            _coreContext= new CoreContext();
        }
        public async Task Import(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var stream = new MemoryStream()){
                    await file.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream)){
                        var worksheet = package.Workbook.Worksheets[0];
                        var products = getExcelProducts(worksheet);
                        await _coreContext.products.AddRangeAsync(products);
                        await _coreContext.SaveChangesAsync();
                        }
                    }
        }
        private IEnumerable<Product> getExcelProducts(ExcelWorksheet worksheet)
        {
            var products = new List<Product>();
            var rowCount = worksheet.Dimension.Rows;
            for (int row = 2; row <= rowCount; row++)
            {
                string productName = worksheet.Cells[row, 1].Text;
                string productDescription = worksheet.Cells[row, 2].Text;
                string categoryString = worksheet.Cells[row, 3].Text;
                var category = (ProductCategory)Enum.Parse(typeof(ProductCategory), categoryString, true);
                double price = double.Parse(worksheet.Cells[row, 4].Text);
                products.Add(new Product(productName, productDescription, category, price));
            }
            return products;
        }
    }

}
