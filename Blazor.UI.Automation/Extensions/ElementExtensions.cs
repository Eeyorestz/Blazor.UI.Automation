using OpenQA.Selenium;

namespace Blazor.UI.Automation
{
    public static class ElementExtensions
    {
        public static string InnerText(this IWebElement element) => element.GetAttribute("innerText");

        public static string InnerText(this By element)
        {
            ElementWaiter wait = new ElementWaiter();
            return wait.WaitUntillReady(element).GetAttribute("innerText");
        }
        public static void Click(this By element)
        {
            ElementWaiter wait = new ElementWaiter();
            wait.WaitToBeClickable(element).Click();
        }

        public static void SetText(this By element, string text)
        {
            ElementWaiter wait = new ElementWaiter();
            var interactableElement = wait.WaitUntillReady(element);
            interactableElement.Clear();
            interactableElement.SendKeys(text);
        }
    }
}
