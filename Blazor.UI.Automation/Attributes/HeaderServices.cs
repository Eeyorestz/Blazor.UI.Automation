using System.Linq;
using System.Reflection;

namespace Blazor.UI.Automation.Attributes
{
    public class HeaderServices
    {
        public string GetHeaderNameByProperty(PropertyInfo property)
        {
            string headerName;
            var headerNameAttribute = property.GetCustomAttributes(typeof(HeaderNameAttribute)).FirstOrDefault();
            if (headerNameAttribute != null)
            {
                headerName = ((HeaderNameAttribute)headerNameAttribute).Name;
                return headerName;
            }
            else 
            {
                return default;
            }
        }
    }
}
