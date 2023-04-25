using AventStack.ExtentReports;
using Core_Framework;
using Core_Framework.Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SAP.Applications;
using TechTalk.SpecFlow;

namespace SAP.Steps
{
    public class StepDefinition
    {
        protected readonly ScenarioContext _scenarioContext;
        public static SAPWebApplication SAPWeb { get; set; }
        public static SAPS4_Application SAP { get; set; }
        protected Core Core { get; set; }
        protected IWebDriver _driver { get; set; }

        public StepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Core = scenarioContext.Get<Core>("Core");
        }

        public void GetDriver()
        {
            try
            {
                _driver = _scenarioContext.Get<IWebDriver>("driver");
            }
            catch
            {

                _driver = null;
            }
        }

        public IWebDriver GetChromeDriver(ChromeOptions options = null)
        {
            if (options == null) options = new ChromeOptions();
            options.AddArgument("--window-size=1920,1080");
            var driver = new ChromeDriver(options);
            Core.Selenium.SetDriver(driver);
            return driver;
        }

        public void InfoScreenshot(string message)
        {
            byte[] screenshot = null;
            if (Core.Selenium.DriverRunning())
            {
                screenshot = Core.Selenium.TakeScreenshot();
            }
            else if (Core.Desktop != null)
            {
                screenshot = Core.Desktop.TakeScreenshot();
            }

            GherkinKeyword key = new GherkinKeyword(_scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString());
            ExtentReporter.LogScreenshot(_scenarioContext.Get<ExtentTest>("ScenarioNode"),
                key,
                _scenarioContext.StepContext.StepInfo.Text,
                message,
                screenshot);
        }

        public void LogJson(string label, string body)
        {
            GherkinKeyword key = new GherkinKeyword(_scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString());
            ExtentReporter.LogJson(_scenarioContext.Get<ExtentTest>("ScenarioNode"),
                key,
                 _scenarioContext.StepContext.StepInfo.Text,
                label,
                body);
        }
    }
}
