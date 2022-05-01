using MantisTestProject.Enum_Entity;
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
        protected MantisTaskPage? mantisTaskPage;

        [OneTimeSetUp]
        protected void SetupDriver()
        {
            driver = BasePage.CreateDriver(TypeOfDriver.Chrome);
            basePage = new BasePage(driver);
            mantisHomePage = new MantisHomePage(driver);
            mantisLogInPage = new MantisLogInPage(driver);
            mantisTaskPage = new MantisTaskPage(driver);


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
