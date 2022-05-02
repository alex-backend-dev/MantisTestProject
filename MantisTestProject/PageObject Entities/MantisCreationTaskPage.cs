using MantisTestProject.Constant_Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace MantisTestProject.PageObject_Entities
{
    public class MantisCreationTaskPage : BasePage
    {
        private string? _platformInfo;
        private string? _operationSystemInfo;
        private string? _operationSystemBuildInfo;
        private string? _summaryInfo;
        private string? _descriptionInfo;
        private string? _stepsToReproduceInfo;
        private string? _additionalInfo;


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
        private By NavigationBar = By.XPath("//a[@class = 'navbar-brand']");
        private By ListOfTasks = By.XPath("//span[@class = 'issue_id']");

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
        private IWebElement GetNavigationBar => driver.FindElement(NavigationBar);

        private IList<IWebElement> GetListOfTasks => driver.FindElements(ListOfTasks);


        public MantisCreationTaskPage(IWebDriver driver) : base(driver)
        {
        }

        private MantisCreationTaskPage ChooseReproducibilityOption()
        {
            ClickOnRandomOptionInDropDown(GetReproducibilityDropDown);
            return this;
        }

        private MantisCreationTaskPage ChooseSeverityOption()
        {
            ClickOnRandomOptionInDropDown(GetSeverityDropDown);
            return this; 
        }

        private MantisCreationTaskPage ChoosePriortyOption()
        {
            ClickOnRandomOptionInDropDown(GetPriorityDropDown);
            return this;
        }

        private MantisCreationTaskPage PlatformInfoInitialize(string platformInfo)
        {
            _platformInfo = platformInfo;
            return this;
        }

        private MantisCreationTaskPage OperationSystemInfoInitialize(string operationSystemInfo)
        {
            _operationSystemInfo = operationSystemInfo;
            return this;
        }

        private MantisCreationTaskPage OperationSystemBuildInitialize(string operationSystemBuildInfo)
        {
            _operationSystemBuildInfo = operationSystemBuildInfo;
            return this;
        }

        private MantisCreationTaskPage ChooseProductVersionOption()
        {
            ClickOnRandomOptionInDropDown(GetProductVersionDropDown);
            return this;
        }

        private MantisCreationTaskPage InsertSummaryInfo(string summaryInfo)
        {
            _summaryInfo = summaryInfo;
            return this;
        }

        private MantisCreationTaskPage InsertDescriptionField(string descriptionInfo)
        {
            _descriptionInfo = descriptionInfo;
            return this;
        }

        private MantisCreationTaskPage InsertStepsToReproduceField(string stepsToReproduceInfo)
        {
            _stepsToReproduceInfo = stepsToReproduceInfo;
            return this;
        }

        private MantisCreationTaskPage InsertAdditionalInfoField(string additionalInfo)
        {
            _additionalInfo = additionalInfo;
            return this;
        }

        private MantisCreationTaskPage ClickReportStayRadioButton()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(GetReportStayRadioButton).Click().Perform();
            return this;
        }

        private MantisCreationTaskPage ClickCreateTaskButton()
        {
            GetCreateTaskButton.Click();
            return this;
        }

        public bool IsReportBugFormDisplayed()
        {
            return IsDisplayed(driver, ReportBugForm, 4);
        }

        public MantisHomePage ClickMantisBtLogo()
        {
            GetNavigationBar.Click();
            return new MantisHomePage(driver);
        }

        public MantisResultedTaskPage ClickFirstIdTask()
        {
            GetListOfTasks[0].Click();
            return new MantisResultedTaskPage(driver); 
        }


        public void ParametersInitialize()
        {
            PlatformInfoInitialize(MantisConstants.TaskInfo.PlatformInfo);
            OperationSystemInfoInitialize(MantisConstants.TaskInfo.OperationInfo);
            OperationSystemBuildInitialize(MantisConstants.TaskInfo.OperationSystemVersion);
            InsertSummaryInfo(MantisConstants.TaskInfo.SummaryTaskInfo);
            InsertDescriptionField(MantisConstants.TaskInfo.DescriptionInfo);
            InsertStepsToReproduceField(MantisConstants.TaskInfo.StepsToReproduceInfo);
            InsertAdditionalInfoField(MantisConstants.TaskInfo.AdditionalInfo);
        }

        public void TaskCreaterBuilder()
        {
            ChooseReproducibilityOption();
            ChooseSeverityOption();
            ChoosePriortyOption();
            GetPlatformField.Click();
            GetPlatformField.SendKeys(_platformInfo);
            GetOperationSystemField.Click();
            GetOperationSystemField.SendKeys(_operationSystemInfo);
            GetOperationSystemBuildField.Click();
            GetOperationSystemBuildField.SendKeys(_operationSystemBuildInfo);
            ChooseProductVersionOption();
            GetSummatyField.Click();
            GetSummatyField.SendKeys(_summaryInfo);
            GetDescriptionTaskField.Click();
            GetDescriptionTaskField.SendKeys(_descriptionInfo);
            GetStepsToReproduceField.Click();
            GetStepsToReproduceField.SendKeys(_stepsToReproduceInfo);
            GetAdditionalInfoField.Click();
            GetAdditionalInfoField.SendKeys(_additionalInfo);
            ClickReportStayRadioButton();
            ClickCreateTaskButton();
        }
    }
}
