using OpenQA.Selenium;

namespace MantisTestProject.PageObject_Entities
{
    public class MantisHomePage : BasePage
    {
        private By LogInButton = By.XPath("//a[text() = 'Вход']");
        private By CreateTaskButton = By.XPath("//a[contains(text(), 'Создать задачу')]");

        private IWebElement GetLogInButton => driver.FindElement(LogInButton);
        private IWebElement GetCreateTaskButton => driver.FindElement(CreateTaskButton);

        public MantisHomePage(IWebDriver driver) : base(driver)
        {
        }

        public MantisLogInPage ClickLogInButton()
        {
            GetLogInButton.Click();
            return new MantisLogInPage(driver);
        }

        public MantisTaskPage ClickCreateTaskButton()
        {
            GetCreateTaskButton.Click();
            return new MantisTaskPage(driver);
        }
    }
}
