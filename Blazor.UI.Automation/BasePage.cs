using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Blazor.UI.Automation
{
    public class BasePage : Browser
    {
        public ElementWaiter Wait { get; set; }

        public BasePage()
        {
            Wait = new ElementWaiter();
        }

        public static void DragAndDrop(IWebElement fromElement, IWebElement toElement)
        {
            var builder = new Actions(Driver);
            builder.DragAndDrop(fromElement, toElement).Perform();
        }
    }
}