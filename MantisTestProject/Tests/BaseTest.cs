using Allure.Commons;
using MantisTestProject.Enum_Entity;
using MantisTestProject.Helper;
using MantisTestProject.PageObject_Entities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace MantisTestProject.Tests
{
    public class BaseTest
    {
        protected IWebDriver? driver;
        protected BasePage? basePage;
        protected MantisHomePage? mantisHomePage;
        protected MantisLogInPage? mantisLogInPage;
        protected MantisCreationTaskPage? mantisCreationTaskPage;
        protected MantisResultedTaskPage? mantisResultedTaskPage;

        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [OneTimeSetUp]
        protected void Setup()
        {
            driver = DriverHelper.CreateDriver(TypeOfDriver.Chrome);
            basePage = new BasePage(driver);
            mantisHomePage = new MantisHomePage(driver);
            mantisLogInPage = new MantisLogInPage(driver);
            mantisCreationTaskPage = new MantisCreationTaskPage(driver);
            mantisResultedTaskPage = new MantisResultedTaskPage(driver);


            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        }

        [OneTimeTearDown]
        protected void QuitDriver()
        {
            if (driver != null)
            {
                driver?.Quit();
            }
        }
    }
}
