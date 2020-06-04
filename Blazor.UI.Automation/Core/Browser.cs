using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Blazor.UI.Automation
{
    public class Browser
    {
        public static IWebDriver Driver;

        public static void SetupDriver() 
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }
    }
}
