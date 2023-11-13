namespace NewRepo.Entity
{
    public class Invoice 
    {
        public long InvoiceId { get; set; }
        public string InvoiceNumber { get; set;}
        public double InvoiceGrossPrice { get; set; }
        public double InvoiceNetPrice { get; set; }
        public Order order { get; set; }
        public long OrderId {  get; set; }
        public DateTime createdDate { get; set; }
        private Invoice()
        {
            createdDate = DateTime.Now;
        }
        public Invoice(double InvoiceGrossPrice, double InvoiceNetPrice, Order order)
        {
            this.order = order;
            this.InvoiceGrossPrice = InvoiceGrossPrice;
            this.InvoiceNetPrice = InvoiceNetPrice;
            this.InvoiceNumber=generateInvoiceNumber();
            createdDate = DateTime.Now;
        }
        private string generateInvoiceNumber()
        {
            return string.Join("/", "INV", DateTime.Now.Date.ToString("yyyy-MM-dd"), order.OrderId);
        }
    }
}
