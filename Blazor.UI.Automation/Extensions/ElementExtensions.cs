using OpenQA.Selenium;

namespace Blazor.UI.Automation
{
    public static class ElementExtensions
    {
        public static string InnerText(this IWebElement element) => element.GetAttribute("innerText");

        public static string InnerText(this By element)
        {
            ElementWaits wait = new ElementWaits();
            return wait.WaitUntillReady(element).GetAttribute("innerText");
        }
        public static void Click(this By element)
        {
            ElementWaits wait = new ElementWaits();
            wait.WaitToBeClickable(element).Click();
        }

        public static void SetText(this By element, string text)
        {
            ElementWaits wait = new ElementWaits();
            var interactableElement = wait.WaitUntillReady(element);
            interactableElement.Clear();
            interactableElement.SendKeys(text);
        }
    }
}
