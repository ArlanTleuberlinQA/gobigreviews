using NUnit.Framework;
using OpenQA.Selenium;
using Gobigreviews.Drivers;
using OpenQA.Selenium.Support.UI;
using Gobigreviews.Pages;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;


namespace Gobigreviews.Tests
{
public class RegistrationTests
{
private IWebDriver driver;
private Main quickCalls;
[SetUp]
public void SetUp()
{
driver = WebDriverFactory.Create();
quickCalls = new Main(driver);
quickCalls.Open();
}
[Test]
public void EmailRegistrationTest()
{
    Assert.Multiple(() =>
    {
    Assert.That(quickCalls.Registration.IsSingInDisplayed, "Sign in not displayed");
    quickCalls.Registration.ClickOnSingIn();
    Assert.That(quickCalls.Registration.IsSignUpDisplayed, "SignUp not displayed");
    quickCalls.Registration.ClickOnSignUp();
    Assert.That(quickCalls.Registration.IsAllRegistrationElementsDisplayed);
    string randomName = quickCalls.Registration.FakeNameGenerate();
    string randomMail = quickCalls.Registration.FakeEmailGenerate();
    string randomPass = "!Yu1"+randomName;
    quickCalls.Registration.RegistrationFill(randomName, randomMail, randomPass);
    Assert.That(quickCalls.Registration.IsUserIconDisplayed);
    quickCalls.Registration.LogOutFromMainScreen();
    Assert.That(quickCalls.Registration.IsSingInDisplayed, "Sign in not displayed");
    Assert.That(quickCalls.Registration.IsUserIconDisplayed,Is.False);

    });


}

[TearDown]
public void TearDown()
{
driver.Quit();
driver.Dispose();
}
}
}