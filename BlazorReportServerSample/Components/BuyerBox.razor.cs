using BlazorReportServerSample.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorReportServerSample.Components
{
	public partial class BuyerBox
	{
		[Parameter] public Invoice Invoice { get; set; }
	}
}
