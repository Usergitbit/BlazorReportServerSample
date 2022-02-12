using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorReportServerSample.Components
{
    public partial class A4Page
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public RenderFragment HeaderContent { get; set; }
        [Parameter]
        public RenderFragment FooterContent { get; set; }
    }
}
