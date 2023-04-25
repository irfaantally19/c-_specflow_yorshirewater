using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Core_Framework;
using Core_Framework.Desktop.CodedUI;
using Core_Framework.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SAP.Hooks
{
    [Binding]
    public class CoreHook
    {
        [ThreadStatic] public static Core Core;

        [BeforeFeature]
        public static void SetupStuffForFeatures(FeatureContext featureContext)
        {
            string reportDirectory = Environment.CurrentDirectory;
            reportDirectory = Directory.GetParent(reportDirectory).Parent.Parent.FullName;
            reportDirectory += $"/Reports/{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}/";

            ExtentReporter.Setup(reportDirectory);
            ExtentTest extentFeature = ExtentReporter.ExtentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            featureContext.Add("FeatureReport", extentFeature);
        }

        [AfterFeature]
        public static void FeatureTeardown(FeatureContext featureContext)
        {
            ExtentReporter.ExtentReport.Flush();
        }

        [BeforeScenario]
        public void Setup(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            ExtentTest extentFeature = featureContext.Get<ExtentTest>("FeatureReport");
            ExtentTest extentScenario = extentFeature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            scenarioContext.Add("ScenarioNode", extentScenario);
            ExtentReporter.CurrentTest = extentScenario;
            Core = new Core();
            scenarioContext.Add("Core", Core);

            var browser = TestContext.Parameters.Get("Browser");
            if (browser != null)
            {

                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--no-sandbox");

                Proxy proxy = new Proxy();
                proxy.HttpProxy = null;
                chromeOptions.Proxy = proxy;
                var service = ChromeDriverService.CreateDefaultService();
                chromeOptions.AddArgument("--no-sandbox");
                service.LogPath = "chromedriver.log";
                service.EnableVerboseLogging = true;

                var driver = browser.ToLower() switch
                {
                    "chrome" => new ChromeDriver(service, chromeOptions),
                    "edge" => Core.Selenium.GetEdgeDriver(),
                    _ => new ChromeDriver()
                };

                Core.Selenium.SetDriver(driver);

                driver.Manage().Window.Maximize();

                scenarioContext.Add("driver", driver);
            }
        }

        [AfterStep]
        public void StepResult()
        {
            var scenarioContext = ScenarioContext.Current;

            ExtentTest scenarioNode = scenarioContext.Get<ExtentTest>("ScenarioNode");
            var Core = scenarioContext.Get<Core>("Core");

            GherkinKeyword key = new GherkinKeyword(scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString());

            if (scenarioContext.ScenarioExecutionStatus.Equals(ScenarioExecutionStatus.OK))
            {
                scenarioNode.CreateNode(key, scenarioContext.StepContext.StepInfo.Text).Pass("pass");
            }
            else
            {
                string errMsg = scenarioContext.TestError.Message;
                string stackTrace = scenarioContext.TestError.StackTrace;

                if (Core.Selenium.DriverRunning())
                {
                    ExtentReporter.StepFailure(scenarioNode, key, scenarioContext.StepContext.StepInfo.Text, errMsg, stackTrace, SeleniumScreenshot(scenarioContext));
                }
                else
                {
                    ExtentReporter.StepFailure(scenarioNode, key, scenarioContext.StepContext.StepInfo.Text, errMsg, stackTrace);
                }


                scenarioNode.CreateNode(key, scenarioContext.StepContext.StepInfo.Text).Fail("fail");
            }
        }

        public byte[] SeleniumScreenshot(ScenarioContext scenarioContext)
        {
            var driver = scenarioContext.Get<IWebDriver>("driver");
            return ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
        }

        [AfterScenario]
        public void Teardown(ScenarioContext scenarioContext)
        {
            Core.Dispose();

            try
            {
                var driver = scenarioContext.Get<IWebDriver>("driver");
                driver.Close();
                driver.Quit();
            }
            catch
            {

            }


        }
    }
}
