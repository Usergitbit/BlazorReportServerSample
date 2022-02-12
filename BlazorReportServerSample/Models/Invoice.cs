using System;
using System.Collections.Generic;

namespace BlazorReportServerSample.Models
{
    public class Invoice
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public DateTime Date { get; set; }
        public BuyerData BuyerData { get; set; }
        public SellerData SellerData { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public string PayType { get; set; }
        public string CreatorName { get; set; }
        public decimal TotalWithoutVat { get; set; }
        public decimal VatValue { get; set; }
        public decimal TotalValue { get; set; }
        public string DelegateName { get; set; }
        public string DelegateCi { get; set; }
        public string TransportType { get; set; }
        public DateTime SentAtDate { get; set; }

        public void CalculateTotals()
        {
            decimal totalWithoutVat = 0;
            decimal vatValue = 0;
            foreach(var item in Items)
            {
                vatValue += item.VatValue;
                totalWithoutVat += item.Value;
            }
            TotalWithoutVat = totalWithoutVat;
            VatValue = vatValue;
            TotalValue = TotalWithoutVat + VatValue;
        }
    }
}
