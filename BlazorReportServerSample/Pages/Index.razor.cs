using BlazorReportServerSample.Models;
using BlazorReportServerSample.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorReportServerSample.Pages
{
    public partial class Index
    {
        [Inject] public DataService DataService { get; set; }
        public Invoice Invoice { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var invoice = DataService.GetInvoiceDetails();
            Invoice = invoice;
        }
    }
}
