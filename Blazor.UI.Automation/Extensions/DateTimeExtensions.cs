using System;
using System.Globalization;

namespace Blazor.UI.Automation
{
    public static class DateTimeExtensions
    {
        public static string FormatDateTime(this DateTime dateTime) 
        {
            return dateTime.ToString("dddd, dd MMM yyyy",
                  CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}
