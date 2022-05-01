using MantisTestProject.Enum_Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MantisTestProject.PageObject_Entities
{
    public class BasePage
    {
        protected readonly IWebDriver? driver;
        public BasePage(IWebDriver driver) => this.driver = driver;

        public void GoTo(string URL)
        {
            driver?.Navigate().GoToUrl(URL);
        }

        public bool AtPageByURL(string URL)
        {
            return driver?.Url == URL;
        }

        public bool AtPageByTitle(string Title)
        {
            return driver?.Title == Title;
        }

        public static IWebDriver CreateDriver(TypeOfDriver typeOfDriver)
        {
            switch (typeOfDriver)
            {
                case TypeOfDriver.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--lang=ru");
                    return new ChromeDriver(options);

                case TypeOfDriver.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver();

                case TypeOfDriver.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();

                default:
                    throw new Exception("Incorrect Browser Name");
            }
        }

        public bool IsDisplayed(IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(by);
                    return elementToBeDisplayed.Displayed;
                }

                catch (StaleElementReferenceException)
                {
                    return false;
                }

                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            return true;
        }

        public SelectElement ClickOnRandomOptionInDropDown(IWebElement webElement)
        {
            SelectElement selectList = new SelectElement(webElement);
            IList<IWebElement> options = selectList.Options;

            int countElements = options.Count;

            Random num = new Random();
            int select = num.Next(0, countElements);

            selectList.SelectByIndex(select);
            return selectList;
        }
    }
}
