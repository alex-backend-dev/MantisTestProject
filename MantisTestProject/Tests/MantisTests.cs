using MantisTestProject.Constant_Entities;
using MantisTestProject.Tests;
using NUnit.Framework;
using System.Threading;

namespace MantisTestProject
{
    [TestFixture]
    public class MantisTests : BaseTest
    {
        [Test, Order(1)]       
        public void AuthorizationTest()
        {
            basePage?.GoTo(MantisConstants.Url.MantisHomePageUrl);

            Assert.IsTrue(mantisHomePage?.AtPageByURL(MantisConstants.Url.MantisHomePageUrl), "Not correct URL of Home Page");
            Assert.IsTrue(mantisHomePage?.AtPageByTitle(MantisConstants.Title.MantisHomePageTitle), "Not correct title of Home Page");

            mantisHomePage?.ClickLogInButton();
            Assert.IsTrue(mantisLogInPage?.AtPageByURL(MantisConstants.Url.MantisLogInPageUrl), "Not correct URL of LogIn Page");
            Assert.IsTrue(mantisLogInPage?.AtPageByTitle(MantisConstants.Title.MantisLogInPageTitle), "Not correct title of LogIn Page");

            mantisLogInPage?.Authorization(MantisConstants.Credential.UserName, MantisConstants.Credential.Password);
            Assert.IsTrue(mantisLogInPage?.IsAuthorsNameDisplayed(), "Authors name isn't displayed");
        }

        [Test, Order(2)]
        public void CreateTaskTest()
        {
            mantisHomePage?.ClickCreateTaskButton();
            Assert.IsTrue(mantisTaskPage?.IsReportBugFormDisplayed(), "Report bug form isn't displayed");
            Assert.IsTrue(mantisTaskPage?.AtPageByTitle(MantisConstants.Title.MantisTaskPageTitle), "Not correct title of Task Page");

            mantisTaskPage?.CreateTask(MantisConstants.TaskInfo.PlatformInfo, MantisConstants.TaskInfo.OperationInfo, MantisConstants.TaskInfo.OperationSystemVersion,
                MantisConstants.TaskInfo.SummaryTaskInfo, MantisConstants.TaskInfo.DescriptionInfo, MantisConstants.TaskInfo.StepsToReproduceInfo, MantisConstants.TaskInfo.AdditionalInfo);

            Thread.Sleep(5000);

        }
    }
}