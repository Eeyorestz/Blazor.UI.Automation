using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Blazor.UI.Automation
{
    public class BasePage : Browser
    {
        public ElementWaits Wait;
        public BasePage()
        {
            Wait = new ElementWaits();
        }

        public static void DragAndDrop(IWebElement element1, IWebElement element2)
        {
            var builder = new Actions(Driver);
            builder.DragAndDrop(element1,element2).Perform();
        }
    }
}
