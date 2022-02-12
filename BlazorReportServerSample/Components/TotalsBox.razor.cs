using BlazorReportServerSample.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorReportServerSample.Components
{
	public partial class TotalsBox
	{
		[Parameter] public Invoice Invoice { get; set; }
	}
}
