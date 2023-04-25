using Newtonsoft.Json;
using SAP.Pages.Models;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SAP.Steps.GUI
{
    [Binding]
    public class StrategicPlanningDefs : StepDefinition
    {
        StrategicPlanningInfo info { get; set; }

        public StrategicPlanningDefs(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        /********************************Time based maintenance strategy***********************************************/
        //WJE20230327
        [When(@"The user adds a maintenance strategy called '(.*)'")]
        public void CreateNewMaintenanceStrategy(string strategy)
        {
            info.MaintenanceStrategy = strategy;
            SAP.StrategicPlanningPage.CreateNewMaintenanceStrategy(info);
        }

        //WJE20230327
        [Then(@"The user validates the maintenance strategy")]
        public void ValidateNewMaintenanceStrategy()
        {
            SAP.StrategicPlanningPage.ValidateNewMaintenanceStrategy(info);
        }

        /********************************Time based strategy package*****************************************************/

        //WJE20230327
        //It is imperitive to note that a time based strategy plan must already exist before a package can be created.
        [When(@"The user adds a strategy package using strategy '(.*)'")]
        public void CreateNewStrategyPackage(string strategy)
        {
            info.MaintenanceStrategy = strategy;
            SAP.StrategicPlanningPage.CreateNewMaintenancePackage(info);
        }

        //WJE20230327
        [Then(@"The user validates the strategy package")]
        public void ValidatesStrategyPackage()
        {
            SAP.StrategicPlanningPage.ValidatesStrategyPackage(info);
        }

        /****************************************************************************************************************/

        //WJE20220720
        [Given(@"The strategic test data is set for a '(.*)'")]
        public void GivenTheTestDataIsSetForA(string jsonFileName)
        {
            var file = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\Data\StrategicPlanning\" + jsonFileName + ".json");
            info = JsonConvert.DeserializeObject<StrategicPlanningInfo>(File.ReadAllText(file));
        }


    }
}
