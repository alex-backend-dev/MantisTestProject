using MantisTestProject.Constant_Entities;
using MantisTestProject.Tests;
using NUnit.Framework;

namespace MantisTestProject
{
    [TestFixture]
    public class MantisTests : BaseTest
    {
        [Test, Order(1)]       
        public void AuthorizationTest()
        {
            basePage?.GoTo(MantisConstants.Url.MantisHomePageUrl);

            Assert.IsTrue(mantisHomePage?.AtPageByURL(MantisConstants.Url.MantisHomePageUrl), $"Not correct URL of Home Page - test received {driver?.Url}");
            Assert.IsTrue(mantisHomePage?.AtPageByTitle(MantisConstants.Title.MantisHomePageTitle), $"Not correct title of Home Page - test received {driver?.Title}");

            mantisHomePage?.ClickLogInButton();
            Assert.IsTrue(mantisLogInPage?.AtPageByURL(MantisConstants.Url.MantisLogInPageUrl), $"Not correct URL of LogIn Page - test received {driver?.Url}");
            Assert.IsTrue(mantisLogInPage?.AtPageByTitle(MantisConstants.Title.MantisLogInPageTitle), $"Not correct title of LogIn Page - test received {driver?.Title}");

            mantisLogInPage?.Authorization(MantisConstants.Credential.UserName, MantisConstants.Credential.Password);
            Assert.IsTrue(mantisLogInPage?.IsAuthorsNameDisplayed(), "Authors name isn't displayed");
        }

        [Test, Order(2)]
        public void CreateTaskTest()
        {
            mantisHomePage?.ClickCreateTaskButton();
            Assert.IsTrue(mantisCreationTaskPage?.IsReportBugFormDisplayed(), "Report bug form isn't displayed");
            Assert.IsTrue(mantisCreationTaskPage?.AtPageByTitle(MantisConstants.Title.MantisTaskPageTitle), $"Not correct title of Task Page - test received {driver?.Title}");

            mantisCreationTaskPage?.ParametersInitialize();
            mantisCreationTaskPage?.TaskCreaterBuilder();

            mantisCreationTaskPage?.ClickMantisBtLogo();
            mantisCreationTaskPage?.ClickFirstIdTask();
            Assert.IsTrue(mantisResultedTaskPage?.IsBugIdDisplayed(), "Bug id isn't displayed");
            Assert.IsTrue(mantisResultedTaskPage?.IsBugReporterIsDisplayed(), "Bug reporter isn't displayed");
            Assert.AreEqual(MantisConstants.Credential.UserName, mantisResultedTaskPage?.GetBugReporter.Text, "Bug reporter name isn't correct");
        }
    }
}