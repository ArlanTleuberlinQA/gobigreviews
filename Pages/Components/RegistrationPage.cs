using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Gobigreviews.Config;
using Gobigreviews.Config.Utils;
using Bogus;
using OpenQA.Selenium.DevTools.V133.Browser;

namespace Gobigreviews.Pages.Components
{
    public class RegComponent
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public RegComponent(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.DefaultTimeout));
        }
    private By SingIn => By.CssSelector("[href='/login']");
    private By SIWG => By.CssSelector("[href='/auth/google']");
    private By FBconnect => By.CssSelector("[href='/auth/facebook']");
    private By Email => By.CssSelector("[type='email']");
    private By Password => By.CssSelector("[type='password']");
    private By SubmitButton => By.CssSelector("[type='submit']");
    private By CheckBox => By.CssSelector("[name='toc']");
    private By SignUp => By.CssSelector("[href='/register']");
    private By Name => By.CssSelector("[name='name']");
    private By RepPass => By.CssSelector("[name='confirm-password']");
    private By UserIcon => By.CssSelector("[alt='GoBigReview-user']");
    private By LogOut => By.CssSelector("[href='/logout']");

    public bool IsSingInDisplayed => UniversalMethods.IsElementDisplayed(driver, SingIn);
    public bool IsSIWGDisplayed => UniversalMethods.IsElementDisplayed(driver, SIWG);
    public bool IsFBconnectDisplayed => UniversalMethods.IsElementDisplayed(driver, FBconnect);
    public bool IsEmailDisplayed => UniversalMethods.IsElementDisplayed(driver, Email);
    public bool IsPassworDisplayed => UniversalMethods.IsElementDisplayed(driver, Password);
    public bool IsSubmitButtonDisplayed => UniversalMethods.IsElementDisplayed(driver, SubmitButton);
    public bool IsCheckBoxDisplayed => UniversalMethods.IsElementDisplayed(driver, CheckBox);
    public bool IsSignUpDisplayed => UniversalMethods.IsElementDisplayed(driver, SignUp);
    public bool IsNameDisplayed => UniversalMethods.IsElementDisplayed(driver, Name);
    public bool IsRepPassDisplayed => UniversalMethods.IsElementDisplayed(driver, RepPass);
    public bool IsUserIconDisplayed => UniversalMethods.IsElementDisplayed(driver, UserIcon);
    public void ClickOnSingIn() => UniversalMethods.ClickElement(driver, SingIn);
    public void ClickOnCheckBox() => UniversalMethods.ClickElement(driver, CheckBox);
    public void ClickOnSignUp() =>UniversalMethods.ClickElement(driver,SignUp);
    public void ClickOnSubmit() => UniversalMethods.ClickElement(driver,SubmitButton);
    public void EnterEmail(string mail) => UniversalMethods.EnterText(driver, Email, mail);
    public void EnterPass(string query) => UniversalMethods.EnterText(driver, Password,query);

    public void RegistrationFill(string name,  string email, string pass) {
        UniversalMethods.EnterText(driver, Name,name);
        EnterEmail(email);
        EnterPass(pass);
        UniversalMethods.EnterText(driver,RepPass,pass);
        ClickOnCheckBox();
        ClickOnSubmit();
    }
public bool IsAllRegistrationElementsDisplayed 
{
    get 
    {
        var missingElements = new List<string>();
        
        if (!IsSIWGDisplayed) missingElements.Add("SIWG");
        if (!IsFBconnectDisplayed) missingElements.Add("Facebook Connect");
        if (!IsEmailDisplayed) missingElements.Add("Email");
        if (!IsPassworDisplayed) missingElements.Add("Password");
        if (!IsSubmitButtonDisplayed) missingElements.Add("Submit Button");
        if (!IsCheckBoxDisplayed) missingElements.Add("Checkbox");
        if (!IsNameDisplayed) missingElements.Add("Name");
        if (!IsRepPassDisplayed) missingElements.Add("Repeat Password");

        if (missingElements.Any())
        {
            Assert.Fail($"Not displayed: {string.Join(", ", missingElements)}");
            return false;
        }
        return true;
    }
}    public string FakeNameGenerate(){
    var faker = new Faker("en");
    string name = faker.Name.FirstName();
    return name;
    }
    
    public string FakeEmailGenerate(){
    var faker = new Faker("en");
    string name = faker.Internet.Email();
    return name;
    }
    
    // public string FakePasswordGenerate(){
    // var faker = new Faker("en");
    // string name = faker.Internet.Password();
    // return name;
    // }
    public void ClickOnUserIcon() => UniversalMethods.ClickElement(driver,UserIcon);
    public void ClickOnUserLogout() => UniversalMethods.ClickElement(driver,LogOut);
    public void LogOutFromMainScreen(){
        ClickOnUserIcon();
        ClickOnUserLogout();
    }

    





    }
}