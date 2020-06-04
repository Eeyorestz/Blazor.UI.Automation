using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.UI.Automation.Attributes
{
    public class HeaderNameAttribute : Attribute
    {
        public HeaderNameAttribute(string name) => Name = name;

        public string Name { get; set; }
    }
}
