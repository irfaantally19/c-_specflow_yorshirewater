using Newtonsoft.Json;
using SAP.Pages.Models;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SAP.Steps.GUI
{
    [Binding]
    public class MaintenancePlanDefs : StepDefinition
    {
        MaintenanceInfo info { get; set; }

        public MaintenancePlanDefs(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [StepDefinition(@"The user creates a new single item maintenance plan using the test set ""(.*)""")]
        public void UserCreatesNewSingleItemMaintenancePlan(string jsonFileName)
        {
            GivenTheTestDataIsSetForA(jsonFileName);
            SAP.MaintenancePlanPage.CreateSingleItemMaintenancePlan(info);
            _scenarioContext.Set(SAP.MaintenancePlanPage.GetMaintenancePlanNumber, "MaintenancePlanNumber");
        }

        [StepDefinition(@"The user creates a new multi item maintenance plan using the test set ""(.*)""")]
        public void UserCreatesNewMultiItemMaintenancePlan(string jsonFileName)
        {
            GivenTheTestDataIsSetForA(jsonFileName);
            SAP.MaintenancePlanPage.CreateMultiItemMaintenancePlan(info, _scenarioContext.Get<string>("MaintenancePlanNumber"));
        }

        [StepDefinition(@"The user creates a new multi item maintenance plan MECH using the test set ""(.*)""")]
        public void UserCreatesNewMultiItemMaintenancePlanMECH(string jsonFileName)
        {
            GivenTheTestDataIsSetForA(jsonFileName);
            SAP.MaintenancePlanPage.CreateMultiItemMaintenancePlanMECH(info, _scenarioContext.Get<string>("MaintenancePlanNumber"));
        }

        [StepDefinition(@"The user validates the single item maintenance plan")]
        public void ValidateSingleItemMaintenancePlan()
        {
            SAP.MaintenancePlanPage.ValidateSingleItemMaintenancePlan(_scenarioContext.Get<string>("MaintenancePlanNumber"));
        }

        [StepDefinition(@"The user validates the multi item maintenance plan")]
        public void ValidateMultiItemMaintenancePlan()
        {
            SAP.MaintenancePlanPage.ValidateMultiItemMaintenancePlan(info, _scenarioContext.Get<string>("MaintenancePlanNumber"));
        }

        [Given(@"The test data is set for a ""(.*)""")]
        public void GivenTheTestDataIsSetForA(string jsonFileName)
        {
            var file = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\Data\MaintenancePlan\" + jsonFileName + ".json");
            info = JsonConvert.DeserializeObject<MaintenanceInfo>(File.ReadAllText(file));
        }

        [StepDefinition(@"The user amends a multi items maintenance plan MECH using the test set ""(.*)""")]
        public void UserAmendsMultiItemMaintenancePlanMECH(string jsonFileName)
        {
            GivenTheTestDataIsSetForA(jsonFileName);
            SAP.MaintenancePlanPage.AmendMultiItemMaintenancePlanMECH(info, _scenarioContext.Get<string>("MaintenancePlanNumber"));
        }

        [StepDefinition(@"The user amends a multi items maintenance plan using the test set ""(.*)""")]
        public void UserAmendsMultiItemMaintenancePlan(string jsonFileName)
        {
            GivenTheTestDataIsSetForA(jsonFileName);
            SAP.MaintenancePlanPage.AmendMultiItemMaintenancePlan(info, _scenarioContext.Get<string>("MaintenancePlanNumber"));
        }

        [StepDefinition(@"The user validates the amendments to a multi item maintenance plan")]
        public void ValidateAmendingMultiItemMaintenancePlan()
        {
            SAP.MaintenancePlanPage.ValidateAmendingMultiItemMaintenancePlan(_scenarioContext.Get<string>("MaintenancePlanNumber"));
        }
    }
}
