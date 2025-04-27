using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Gobigreviews.Config;
using Gobigreviews.Config.Utils;

namespace Gobigreviews.Pages.Components
{
    public class MainComponent
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public MainComponent(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.DefaultTimeout));
        }
        private By Logo => By.ClassName("navbar-brand");
        public void WaitForPageToLoad()
        {
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public bool IsLogoDisplayed() => UniversalMethods.IsElementDisplayed(driver, Logo);

    }

}