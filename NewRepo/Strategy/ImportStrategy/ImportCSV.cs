using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using NewRepo.Context;
using NewRepo.Entity;
using NewRepo.Enums;
using System.Globalization;

namespace NewRepo.Strategy.ImportStrategy
{
    class ImportCSV : IImportStrategy
    {
        private readonly CoreContext _coreContext;
        private readonly CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture){Delimiter = ";"};

        public ImportCSV()
        {
            _coreContext = new CoreContext();
        }
        
        public async Task Import(IFormFile file)
        {
            var records= processFile(file);
            await _coreContext.products.AddRangeAsync(records);
            await _coreContext.SaveChangesAsync();
        }

        private List<Product> processFile(IFormFile file)
        {
            var products= new List<Product>();
            using (var reader = new StreamReader(file.OpenReadStream()))
                {
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<ProductMap>();
                    var records = csv.GetRecords<Product>();
                    products = records.ToList();

                }
            }
            return products;
        }

        private class ProductMap : ClassMap<Product>
        {
            public ProductMap()
            {
                Map(p => p.ProductId).Ignore();
                Map(m => m.productName).Name("productName");
                Map(m => m.productDescription).Name("productDescription");
                Map(m => m.category).Name("category").TypeConverter<EnumConventer<ProductCategory>>();
                Map(m => m.price).Name("price").TypeConverter<DoubleConverter>();
            }
        }
        private class EnumConventer<T> : DefaultTypeConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return base.ConvertFromString(text, row, memberMapData);
                }

                return Enum.Parse(typeof(T), text, true);
            }
        }
    }


}
