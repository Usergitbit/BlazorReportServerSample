namespace BlazorReportServerSample.Models
{ 
    public class Item
    {
        public int RowNumber { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal GreenTax { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Value { get; set; }
        public decimal VatValue { get; set; }

    }
}
