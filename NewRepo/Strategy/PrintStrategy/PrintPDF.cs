using ceTe.DynamicPDF;
using NewRepo.Entity;
using ceTe.DynamicPDF.PageElements;
namespace NewRepo.Strategy.PrintStrategy
{
    class PrintPDF : IPrintStrategy
    {
        public void Print(Invoice invoice)
        {

            Document document = new Document();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            string labelText = string.Join(" ", "faktura nr ", invoice.InvoiceNumber);
            Label label = new Label(labelText, 0, 0, 504, 100, ceTe.DynamicPDF.Font.Helvetica, 18, TextAlign.Center);
            invoice.order.products.ForEach(product =>  Console.WriteLine(product.productName) );
            page.Elements.Add(label);

            document.Draw("Output.pdf");
        }
    }
}
