using OpenQA.Selenium;

namespace MantisTestProject.PageObject_Entities
{
    public class MantisResultedTaskPage : BasePage
    {
        private By BugId = By.XPath("//td[@class = 'bug-id']");
        private By BugReporter = By.XPath("//td[@class = 'bug-reporter']");

        public IWebElement GetBugReporter => driver.FindElement(BugReporter);

        public MantisResultedTaskPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsBugIdDisplayed()
        {
            return IsDisplayed(driver, BugId, 4);
        }

        public bool IsBugReporterIsDisplayed()
        {
            return IsDisplayed(driver, BugReporter, 4);
        }


    }
}
