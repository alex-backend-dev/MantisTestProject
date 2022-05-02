using MantisTestProject.Enum_Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MantisTestProject.Helper

{
    public static class DriverHelper
    {
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
    }
}
