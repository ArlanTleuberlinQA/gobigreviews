using OpenQA.Selenium;
using Gobigreviews.Pages.Components;
using Gobigreviews.Config;

namespace Gobigreviews.Pages
{
public class Main
{
private readonly IWebDriver driver;
public Main(IWebDriver driver)
{
this.driver = driver;
Header = new MainComponent(driver);
Registration = new RegComponent(driver);
}
public MainComponent Header { get; }
public RegComponent Registration { get; }
public void Open() => driver.Navigate().GoToUrl(Settings.BaseURL);
}
}