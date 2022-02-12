using BlazorReportServerSample.Models;
using Bogus;
using System;

namespace BlazorReportServerSample.Services
{
    public class DataService
    {
        private static int rowNumber = 1;
        private static readonly Faker<Invoice> invoiceFaker = new Faker<Invoice>()
            .RuleFor(i => i.Number, f => f.Random.Int(1, 10000))
            .RuleFor(i => i.Series, "SV")
            .RuleFor(i => i.CreatorName, f => f.Name.FullName())
            .RuleFor(i => i.DelegateName, f => f.Name.FullName())
            .RuleFor(i => i.Items, f => orderItemFaker.GenerateBetween(10, 50))
            .RuleFor(i => i.BuyerData, f => buyerDataFaker.Generate())
            .RuleFor(i => i.SellerData, f => sellerDataFaker.Generate())
            .RuleFor(i => i.TransportType, f => $"{f.Vehicle.Type()} {f.Vehicle.Model()}")
            .RuleFor(i => i.Date, f => f.Date.Future())
            .RuleFor(i => i.DelegateCi, f => f.Random.AlphaNumeric(14))
            .RuleFor(i => i.PayType, f => f.Finance.TransactionType())
            .RuleFor(i => i.SentAtDate, f => f.Date.Recent());
        private static readonly Faker<BuyerData> buyerDataFaker = new Faker<BuyerData>()
            .RuleFor(i => i.Name, f => f.Name.FullName())
            .RuleFor(a => a.Address, f => f.Address.FullAddress())
            .RuleFor(i => i.Ci, f => f.Random.AlphaNumeric(14))
            .RuleFor(a => a.Country, f => f.Address.Country())
            .RuleFor(a => a.Iban, f => f.Finance.Iban());
        private static readonly Faker<SellerData> sellerDataFaker = new Faker<SellerData>()
            .RuleFor(a => a.Name, f => f.Company.CompanyName())
            .RuleFor(i => i.NrOrc, f => $"{f.Random.Int(100, 1000)}/{f.Random.Int()}")
            .RuleFor(a => a.Iban, f => f.Finance.Iban())
            .RuleFor(a => a.Capital, f => $"{f.Random.Decimal(1, 10000, 2)} RON")
            .RuleFor(a => a.Address, f => f.Address.FullAddress())
            .RuleFor(a => a.Bank, f => f.Company.CompanyName())
            .RuleFor(a => a.PhoneFax, f => f.Phone.PhoneNumber())
            .RuleFor(a => a.Cui, f => $"RO {f.Random.Int(1000, 10000)}");
        private static readonly Faker<Item> orderItemFaker = new Faker<Item>()
            .RuleFor(oi => oi.Name, f => f.Commerce.Product())
            .RuleFor(oi => oi.UnitPrice, f => f.Random.Decimal(1, 100, 2))
            .RuleFor(oi => oi.Quantity, f => f.Random.Int(1, 10))
            .RuleFor(oi => oi.Value, (o, i) => i.Quantity * i.UnitPrice)
            .RuleFor(oi => oi.GreenTax, 5)
            .RuleFor(oi => oi.RowNumber, f => rowNumber++)
            .RuleFor(oi => oi.VatValue, (o, i) => i.Value * 0.19m);

        public Invoice GetInvoiceDetails()
        {
            rowNumber = 1;
            var invoice = invoiceFaker.Generate();
            invoice.CalculateTotals();

            return invoice;
        }

        public string GetImage()
        {
            return new Faker().Image.PicsumUrl();
        }
    }

    public static class ExtensionsForRandomizer
    {
        public static decimal Decimal(this Randomizer r, decimal min = 0.0m, decimal max = 1.0m, int? decimals = null)
        {
            var value = r.Decimal(min, max);
            if (decimals.HasValue)
            {
                return Math.Round(value, decimals.Value);
            }
            return value;
        }
    }
}
