using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MantisTestProject.PageObject_Entities
{
    public class MantisTaskPage : BasePage
    {
        private By ReportBugForm = By.Id("report_bug_form");
        private By RepdoducibilityDropDown = By.Id("reproducibility");
        private By SeverityDropDown = By.Id("severity");
        private By PriorityDropDown = By.Id("priority");
        private By PlatformField = By.Id("platform");
        private By OperationSystemField = By.Id("os");
        private By OperationSystemBuildField = By.Id("os_build");
        private By ProductVersionDropDown = By.Id("product_version");
        private By SummaryField = By.Id("summary");
        private By DescriptionTaskField = By.Id("description");
        private By StepsToReproduceField = By.Id("steps_to_reproduce");
        private By AdditionalInfoField = By.Id("additional_info");
        private By ReportStayRadioButton = By.Id("report_stay");
        private By CreateTaskButton = By.XPath("//input[@value = 'Создать задачу']");

        private IWebElement GetReproducibilityDropDown => driver.FindElement(RepdoducibilityDropDown);
        private IWebElement GetSeverityDropDown => driver.FindElement(SeverityDropDown);    
        private IWebElement GetPriorityDropDown => driver.FindElement(PriorityDropDown);
        private IWebElement GetPlatformField => driver.FindElement(PlatformField);
        private IWebElement GetOperationSystemField => driver.FindElement(OperationSystemField);
        private IWebElement GetOperationSystemBuildField => driver.FindElement(OperationSystemBuildField);
        private IWebElement GetProductVersionDropDown => driver.FindElement(ProductVersionDropDown);
        private IWebElement GetSummatyField => driver.FindElement(SummaryField);
        private IWebElement GetDescriptionTaskField => driver.FindElement(DescriptionTaskField);
        private IWebElement GetStepsToReproduceField => driver.FindElement(StepsToReproduceField);
        private IWebElement GetAdditionalInfoField => driver.FindElement(AdditionalInfoField);
        private IWebElement GetReportStayRadioButton => driver.FindElement(ReportStayRadioButton);
        private IWebElement GetCreateTaskButton => driver.FindElement(CreateTaskButton);    


        public MantisTaskPage(IWebDriver driver) : base(driver)
        {
        }

        private MantisTaskPage ChooseReproducibilityOption()
        {
            ClickOnRandomOptionInDropDown(GetReproducibilityDropDown);
            return this;
        }

        private MantisTaskPage ChooseSeverityOption()
        {
            ClickOnRandomOptionInDropDown(GetSeverityDropDown);
            return this; 
        }

        private MantisTaskPage ChoosePriortyOption()
        {
            ClickOnRandomOptionInDropDown(GetPriorityDropDown);
            return this;
        }

        private MantisTaskPage InsertPlatformInfo(string platformInfo)
        {
            GetPlatformField.Click();
            GetPlatformField.SendKeys(platformInfo);
            return this;
        }

        private MantisTaskPage InsertOperationSystemInfo(string operationSystemInfo)
        {
            GetOperationSystemField.Click();
            GetOperationSystemField.SendKeys(operationSystemInfo);
            return this;
        }

        private MantisTaskPage InsertOperationSystemBuildInfo(string operationSystemBuildInfo)
        {
            GetOperationSystemBuildField.Click();
            GetOperationSystemBuildField.SendKeys(operationSystemBuildInfo);
            return this;
        }

        private MantisTaskPage ChooseProductVersionOption()
        {
            ClickOnRandomOptionInDropDown(GetProductVersionDropDown);
            return this;
        }

        private MantisTaskPage InsertSummaryInfo(string summaryInfo)
        {
            GetSummatyField.Click();
            GetSummatyField.SendKeys(summaryInfo);
            return this;
        }

        private MantisTaskPage InsertDescriptionField(string descriptionInfo)
        {
            GetDescriptionTaskField.Click();
            GetDescriptionTaskField.SendKeys(descriptionInfo);
            return this;
        }

        private MantisTaskPage InsertStepsToReproduceField(string stepsToReproduceInfo)
        {
            GetStepsToReproduceField.Click();
            GetStepsToReproduceField.SendKeys(stepsToReproduceInfo);
            return this;
        }

        private MantisTaskPage InsertAdditionalInfoField(string additionalInfo)
        {
            GetAdditionalInfoField.Click();
            GetAdditionalInfoField.SendKeys(additionalInfo);
            return this;
        }

        private MantisTaskPage ClickReportStayRadioButton()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(GetReportStayRadioButton).Click().Perform();
            return this;
        }

        private MantisTaskPage ClickCreateTaskButton()
        {
            GetCreateTaskButton.Click();
            return this;
        }

        public bool IsReportBugFormDisplayed()
        {
            return IsDisplayed(driver, ReportBugForm, 4);
        }


        public void CreateTask(string platformInfo, string operationSystemInfo, 
            string operationSystemBuildInfo, string summaryInformation, string descriptionInfo, string stepsToReproduceInfo, string additionalInfo)
        {
            ChooseReproducibilityOption();
            ChooseSeverityOption();
            ChoosePriortyOption();
            InsertPlatformInfo(platformInfo);
            InsertOperationSystemInfo(operationSystemInfo);
            InsertOperationSystemBuildInfo(operationSystemBuildInfo);
            ChooseProductVersionOption();
            InsertSummaryInfo(summaryInformation);
            InsertDescriptionField(descriptionInfo);
            InsertStepsToReproduceField(stepsToReproduceInfo);
            InsertAdditionalInfoField(additionalInfo);
            ClickReportStayRadioButton();
            ClickCreateTaskButton();
        }
    }
}
