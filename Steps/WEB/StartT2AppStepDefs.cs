using AventStack.ExtentReports.Gherkin.Model;
using SAP.Pages.Models;
using TechTalk.SpecFlow;

namespace SAP.Steps.WEB
{
    [Binding]
    public class StartT2AppStepDefs : GeneralWebSteps
    {
        //private readonly ScenarioContext _scenarioContext;

        public StartT2AppStepDefs(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"T2 is open and logged in")]
        public void GivenT2IsOpenAndLoggedIn()
        {
            
        }
    }
}
