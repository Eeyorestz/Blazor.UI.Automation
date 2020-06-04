using System;
using Blazor.UI.Automation.Attributes;

namespace Blazor.UI.Automation
{
    public class GridModel
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        [HeaderName("Temp. C")]
        public string TempC { get; set; }

        [HeaderName("Temp. F")]
        public string TempF { get; set; }

        [HeaderName("Summary")]
        public string Summary { get; set; }

        public int RowIndex { get; set; }
    }
}
