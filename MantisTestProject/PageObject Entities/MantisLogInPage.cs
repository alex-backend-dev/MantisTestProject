using OpenQA.Selenium;

namespace MantisTestProject.PageObject_Entities
{
    public class MantisLogInPage : BasePage
    {
        private By UserNameField = By.Id("username");
        private By SubmitButtonUserName = By.XPath("//input[@type = 'submit']");
        private By PasswordField = By.Id("password");
        private By RememberCredentialsCheckBox = By.Id("remember-login");
        private By SubmitButtonPassword = By.XPath("//input[@value = 'Вход']");
        private By AuthorsName = By.XPath("//a[text()= 'Rurtis ( Alexander ) ']");


        private IWebElement GetUserName => driver.FindElement(UserNameField);
        private IWebElement GetSubmitButton => driver.FindElement(SubmitButtonUserName);
        private IWebElement GetPasswordField => driver.FindElement(PasswordField);
        private IWebElement GetRememberCredentialsCheckBox => driver.FindElement(RememberCredentialsCheckBox);
        private IWebElement GetSubmitButtonPassword => driver.FindElement(SubmitButtonPassword);    

        public MantisLogInPage(IWebDriver driver) : base(driver)
        {
        }

        private void CheckRememberCredentialsCheckBox()
        {
            if (!GetRememberCredentialsCheckBox.Selected)
            {
                ClickViaAction(GetRememberCredentialsCheckBox);
            }

            else
            {
                GetSubmitButtonPassword.Click();
            }
        }

        private MantisLogInPage InsertUserNameInfo(string userName)
        {
            GetUserName.Click();
            GetUserName.SendKeys(userName);
            GetSubmitButton.Click();
            return this;
        }

        private MantisLogInPage InsertPasswordInfo(string password)
        {
            GetPasswordField.Click();
            GetPasswordField.SendKeys(password);
            CheckRememberCredentialsCheckBox();
            GetSubmitButtonPassword.Click();
            return this;
        }

        public bool IsAuthorsNameDisplayed()
        {
            return IsDisplayed(driver, AuthorsName, 5);
        }

        public MantisHomePage Authorization(string userName, string password)
        {
            InsertUserNameInfo(userName);
            InsertPasswordInfo(password);

            return new MantisHomePage(driver);
        }
    }
}
