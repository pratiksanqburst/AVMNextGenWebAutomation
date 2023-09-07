
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVMNextGenWebAutomation.AVMNextGenAPI;

namespace AVMNextGenWebAutomation.AVMNextGenPageObjects
{
    public class Login:AVMNextGenBase
    {
        public GetAPIResponse getAPIResponse;
        public IWebDriver loginDriver;
        public ExtentReportHelper Loginextent;
        public WebDriverWait loginWait;
        public Login()
        {
           
        }
        public Login(IWebDriver driver)
        {
            this.loginDriver = driver;
        }

        #region Properties
        IWebElement UserNameField => driver.FindElement(By.Id("userName"));
        IWebElement PasswordField => driver.FindElement(By.Id("password"));
        IWebElement EnterCredentialsText => driver.FindElement(By.XPath("//div[contains(@class,'card-body text')]/h3"));
        IWebElement UserNamePlaceholder => driver.FindElement(By.XPath("//input[@id='userName']/following-sibling::span"));
        IWebElement PasswordPlaceholder => driver.FindElement(By.XPath("//input[@id='password']/following-sibling::span"));
        IWebElement ForgotPassword => driver.FindElement(By.PartialLinkText("Forgot password"));
        IWebElement LoginButton => driver.FindElement(By.XPath("//button[@name='submit']"));
        IWebElement EndUserAgreement => driver.FindElement(By.XPath("//p[contains(text(),'End User License Agreement')]"));
        IWebElement Home => driver.FindElement(By.Id("menu-home"));

        IWebElement Vehicles => driver.FindElement(By.XPath("//a[@id='vehicles-icon']"));
        IWebElement ForgotPasswordHeader => driver.FindElement(By.XPath("//h3[contains(@class,'heading-text')]"));
        IWebElement SuggestiveText => driver.FindElement(By.Id("suggestive-text"));
        IWebElement ResetButton => driver.FindElement(By.Id("reset-button"));
        IWebElement ResetCancelButton => driver.FindElement(By.Id("cancel-btn"));
        IWebElement ResetModalHeader => driver.FindElement(By.XPath("//h4[@class='modal-title']"));
        IWebElement ResetModalBody => driver.FindElement(By.XPath("//div[@class='modal-body']"));
        IWebElement ResetModalOk => driver.FindElement(By.Id("modal-ok-btn"));
        IWebElement LogoutDropDown => driver.FindElement(By.Id("logout-dropdown"));
        IWebElement ChangePasswordOption => driver.FindElement(By.Id("change-pwd-option"));
        IWebElement ChangePasswordTitle => driver.FindElement(By.Id("modal-basic-title"));
        IWebElement PasswordFieldChange => driver.FindElement(By.XPath("//input[@formcontrolname='password']"));
        IWebElement ConfirmPasswordField => driver.FindElement(By.XPath("//input[@formcontrolname='confirmPassword']"));
        IWebElement PasswordRulesFirstLine => driver.FindElement(By.XPath("//div[@class='password-rules-wrapper']//ul/li[1]"));
        IWebElement PasswordRulesSecondLine => driver.FindElement(By.XPath("//div[@class='password-rules-wrapper']//ul/li[2]"));
        IWebElement PasswordRulesThirdLine => driver.FindElement(By.XPath("//div[@class='password-rules-wrapper']//ul/li[3]"));
        IWebElement PasswordRulesFourthLine => driver.FindElement(By.XPath("//div[@class='password-rules-wrapper']//ul/li[4]"));
        IWebElement PasswordRulesFifthLine => driver.FindElement(By.XPath("//div[@class='password-rules-wrapper']//ul/li[5]"));
        IWebElement ChangePasswordCancelButton => driver.FindElement(By.Id("change-pwd-cancel-btn"));
        IWebElement ChangePasswordButton => driver.FindElement(By.Id("change-pwd-change-btn"));

        

        #endregion

        #region Methods
        /// <summary>
        /// Verify Login Feature for AVM Lite
        /// </summary>
        /// <param name="UserName">Provide Username</param>
        /// <param name="Password">Provide Username</param>
        public void LoginToAVMLite(string UserName, string Password,bool FM=false)
        {

            Assert.AreEqual("Username", UserNamePlaceholder.Text);
            extent.SetStepStatusPass("Verified username placeholder text.");
            Assert.AreEqual("Password", PasswordPlaceholder.Text);
            extent.SetStepStatusPass("Verified password placeholder text.");
            Assert.AreEqual("Enter your credentials", EnterCredentialsText.Text.Replace("\r\n", " "));
            extent.SetStepStatusPass("Verified enter credentials text.");
            Thread.Sleep(1500);
            UserNameField.SendKeys(UserName);
            extent.SetStepStatusPass($"Username entered as {UserName}.");
            PasswordField.SendKeys(Password);
            extent.SetStepStatusPass($"Password entered as {Password}.");
            Assert.IsTrue(ForgotPassword.Displayed);
            extent.SetStepStatusPass("Verified that forgot password link is displayed.");
            Assert.IsTrue(EndUserAgreement.Displayed);
            extent.SetStepStatusPass("Verified that end user agreement link is displayed.");
            wait.Until(driver => LoginButton.Enabled);
            //LoginButton.Click();
            //extent.SetStepStatusPass($"Clicked on login button.");
            getAPIResponse = new GetAPIResponse();
            var bearerToken = getAPIResponse.getBearerTokenAsync(UserName, Password).Result.ToString().Replace("\"", "");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("localStorage.setItem(arguments[0],arguments[1])", "userToken", bearerToken);
            js.ExecuteScript("localStorage.setItem(arguments[0],arguments[1])", "ClientName", UserName);
            js.ExecuteScript("localStorage.setItem(arguments[0],arguments[1])", "userName", UserName);
            if (FM)
                js.ExecuteScript("localStorage.setItem(arguments[0],arguments[1])", "FleetManager", true);
            driver.Navigate().Refresh();
            wait.Until(driver => Vehicles.Displayed);
            extent.SetStepStatusPass($"Home page is displayed.");
        }
        /// <summary>
        /// Verify forgot password
        /// </summary>
        /// <param name="UserName"></param>
        public void VerifyForgotPassword(string UserName)
        {
            wait.Until(driver => ForgotPassword.Displayed);
            ForgotPassword.Click();
            wait.Until(driver => ForgotPasswordHeader.Displayed);
            Assert.IsTrue(ForgotPasswordHeader.Text.Contains("Forgot your"));
            Assert.IsTrue(ForgotPasswordHeader.Text.Contains("password?"));
            Assert.AreEqual("Username", UserNamePlaceholder.Text);
            UserNameField.SendKeys(UserName);
            Assert.AreEqual("Forgot your username? Please contact operator for help", SuggestiveText.Text);
            wait.Until(driver => ResetCancelButton.Displayed);
            ResetButton.Click();
            wait.Until(driver => ResetModalHeader.Displayed);
            Assert.AreEqual("Reset Password", ResetModalHeader.Text);
            Assert.AreEqual("If this account and email exist, we will send you an email with the link. If you don’t receive an email please try again.", ResetModalBody.Text.Trim());
            ResetModalOk.Click();
            extent.SetStepStatusPass($"Forgot password verified.");
        }
        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="changePassword"></param>
        public void VerifyChangePassword(string changePassword)
        {
            wait.Until(driver => LogoutDropDown.Displayed);
            LogoutDropDown.Click();
            Thread.Sleep(1000);
            ChangePasswordOption.Click();
            wait.Until(driver => ChangePasswordTitle.Displayed);
            Assert.AreEqual("Change Password", ChangePasswordTitle.Text);
            Assert.IsTrue(PasswordRulesFirstLine.Text.Contains("Password must have a minimum"));
            Assert.IsTrue(PasswordRulesFirstLine.Text.Contains("length of 6 characters"));
            Assert.IsTrue(PasswordRulesSecondLine.Text.Contains("At least 1 number is required"));
            Assert.IsTrue(PasswordRulesThirdLine.Text.Contains("At least 1 upper case character"));
            Assert.IsTrue(PasswordRulesFourthLine.Text.Contains("At least 1 lower case character"));
            Assert.IsTrue(PasswordRulesFifthLine.Text.Contains("For example:"));
            Assert.IsTrue(PasswordRulesFifthLine.Text.Contains("po1ntS"));
            PasswordFieldChange.SendKeys(changePassword);
            ConfirmPasswordField.SendKeys(changePassword);
            wait.Until(driver => ChangePasswordCancelButton.Displayed);
            ChangePasswordButton.Click();
            Thread.Sleep(3000);
            wait.Until(driver => UserNamePlaceholder.Displayed);
            extent.SetStepStatusPass($"Change password verified.");
        }

        #endregion
    }
}
