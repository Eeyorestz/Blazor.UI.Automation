using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Blazor.UI.Automation
{
    public class Browser
    {
        public static IWebDriver Driver;

        public static void SetupDriver(bool isHeadless = false) 
        {
            var chromeOptions = new ChromeOptions();
            if (isHeadless) 
            {
                chromeOptions.AddArgument("--headless");
            }

            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Window.Maximize();
        }
    }
}
