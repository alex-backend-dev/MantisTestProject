namespace MantisTestProject.Constant_Entities
{
    public class MantisConstants
    {
        public static class Credential
        {
            public const string UserName = "Rurtis ";
            public const string Password = "110411";
        }

        public static class TaskInfo
        {
            public const string PlatformInfo = "Best platform";
            public const string OperationInfo = "Windows";
            public const string OperationSystemVersion = "11";
            public const string SummaryTaskInfo = "Refund functionality doesn't work";
            public const string DescriptionInfo = "Once we make a purchase and then trying to make a refund, refund doesn't work at all";
            public const string StepsToReproduceInfo = "1 )Make a purchase 2) Make a refund  3) Verify you are not able to make a refund";
            public const string AdditionalInfo = "Make sure you make all steps for reproduction on Windows 11";
        }

        public static class Title
        {
            public const string MantisHomePageTitle = "Обзор - MantisBT";
            public const string MantisLogInPageTitle = "MantisBT";
            public const string MantisTaskPageTitle = "Создать задачу - MantisBT";
        }

        public static class Url
        {
            public const string MantisHomePageUrl = "https://www.mantisbt.org/bugs/my_view_page.php";
            public const string MantisLogInPageUrl = "https://www.mantisbt.org/bugs/login_page.php?return=%2Fbugs%2Fmy_view_page.php";
        }
    }
}
