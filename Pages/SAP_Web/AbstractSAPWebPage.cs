using Core_Framework.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Pages.SAP_Web
{
    public abstract class AbstractSAPWebPage : AbstractPage
    {
        protected AbstractSAPWebPage(IWebDriver dr) : base(dr)
        {
        }

        // Monday
        public static IWebDriver WaitForFrameToBeAvailableAndSwitchToIt(IWebDriver driver, string frameLocotor, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameLocotor));
        }

        // Monday
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementExists(by));
            }
            return driver.FindElement(by);
        }

    }
}
