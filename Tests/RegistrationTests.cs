using NUnit.Framework;
using OpenQA.Selenium;
using Gobigreviews.Drivers;
using OpenQA.Selenium.Support.UI;
using Gobigreviews.Pages;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using Newtonsoft.Json;


namespace Gobigreviews.Tests
{
public class RegistrationTests
{
private IWebDriver driver;
private Main quickCalls;
private TestUserData LoadTestUserData(string filePath)
{
string json = File.ReadAllText(filePath);
return Newtonsoft.Json.JsonConvert.DeserializeObject<TestUserData>(json);
}
private string GenerateRandomEmail(string baseName, string domain = "gmail.com")
{
var random = new Random();
int suffix = random.Next(10000, 99999);
return $"{baseName.ToLower()}+{suffix}@{domain}";
}
private string GenerateRandomPassword(int length = 12)
{
const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
const string lower = "abcdefghijklmnopqrstuvwxyz";
const string digits = "0123456789";
const string special = "!@#$%^&*()-_+=<>?";
var allChars = upper + lower + digits + special;
var random = new Random();
var passwordChars = new List<char>
{
upper[random.Next(upper.Length)],
lower[random.Next(lower.Length)],
digits[random.Next(digits.Length)],
special[random.Next(special.Length)]
};
for (int i = passwordChars.Count; i < length; i++)
{
passwordChars.Add(allChars[random.Next(allChars.Length)]);
}

return new string(passwordChars.OrderBy(x => random.Next()).ToArray());
}
[SetUp]
public void SetUp()
{
driver = WebDriverFactory.Create();
quickCalls = new Main(driver);
quickCalls.Open();
}

// [Test]
// public void EmailRegistrationTest()
// {
//     Assert.Multiple(() =>
//     {
//     Assert.That(quickCalls.Registration.IsSingInDisplayed, "Sign in not displayed");
//     quickCalls.Registration.ClickOnSingIn();
//     Assert.That(quickCalls.Registration.IsSignUpDisplayed, "SignUp not displayed");
//     quickCalls.Registration.ClickOnSignUp();
//     Assert.That(quickCalls.Registration.IsAllRegistrationElementsDisplayed);
//     string randomName = quickCalls.Registration.FakeNameGenerate();
//     string randomMail = quickCalls.Registration.FakeEmailGenerate();
//     string randomPass = "!Yu1"+randomName;
//     quickCalls.Registration.RegistrationFill(randomName, randomMail, randomPass);
//     Assert.That(quickCalls.Registration.IsUserIconDisplayed);
//     quickCalls.Registration.LogOutFromMainScreen();
//     Assert.That(quickCalls.Registration.IsSingInDisplayed, "Sign in not displayed");
//     Assert.That(quickCalls.Registration.IsUserIconDisplayed,Is.False);

//     });
//     }


    [Test]
     public void EmailRegistrationTest2()
     {
        var filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\testData.json"));var userData = LoadTestUserData(filePath);// string password = userData.PasswordPrefix + userData.Name;
     Assert.Multiple(() =>
     {
     Assert.That(quickCalls.Registration.IsSingInDisplayed, "Sign in not displayed");
     quickCalls.Registration.ClickOnSingIn();
     Assert.That(quickCalls.Registration.IsSignUpDisplayed, "SignUp not displayed");
     quickCalls.Registration.ClickOnSignUp();
     Assert.That(quickCalls.Registration.IsAllRegistrationElementsDisplayed);
     string email = GenerateRandomEmail(userData.Name, "gmail.com");
     string password = GenerateRandomPassword(10);
     quickCalls.Registration.RegistrationFill(userData.Name, email, password);
     Assert.That(quickCalls.Registration.IsUserIconDisplayed);
     quickCalls.Registration.LogOutFromMainScreen();
     Assert.That(quickCalls.Registration.IsSingInDisplayed, "Sign in not displayed");
     Assert.That(quickCalls.Registration.IsUserIconDisplayed, Is.False);
     });}


[TearDown]
public void TearDown()
{
driver.Quit();
driver.Dispose();
}
}
}