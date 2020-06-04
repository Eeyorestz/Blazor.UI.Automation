using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blazor.UI.Automation
{
    public class ElementWaits : Browser
    {
        public bool ElementDisplayed(By locator)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(3)).Until(condition: ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
                return Driver.FindElement(locator).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement WaitUntillReady(By locator)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(3)).Until(condition: ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
                return Driver.FindElement(locator);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IList<IWebElement> WaitUntillListReady(By locator)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(3)).Until(condition: ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
                return Driver.FindElements(locator);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IWebElement WaitToBeClickable(By locator)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(3)).Until(condition: ExpectedConditions.ElementToBeClickable(locator));
                return Driver.FindElement(locator);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
