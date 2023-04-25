using Newtonsoft.Json;
using SAP.Pages.Models;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SAP.Steps.GUI
{
    [Binding]
    public class JobPlanningDefs : StepDefinition
    {
        JobPlanningInfo info { get; set; }

        public JobPlanningDefs(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [StepDefinition(@"Given The user creates an order for test set ""(.*)""")]
        public void GivenTheUserCreatesAnOrder(string jsonFileName)
        {
            SAP.JobPlanning.CreateOrder(info);
            _scenarioContext.Get<string>("OrderNumber");
        }

        [StepDefinition(@"The user set operation to SOP and completes planning using the test set ""(.*)""")]
        public void UserSetOperationToSOPAndCompletesPlanningOperations(string jsonFileName)
        {
            GivenTheTestDataIsSetForA(jsonFileName);
            //setting order number key in dictionary -> should be added in the scenario where the order number is created
            _scenarioContext.Set("", "OrderNumber");

            SAP.JobPlanning.SOPAndCompletePlanningOperation(info, _scenarioContext.Get<string>("OrderNumber"));
            _scenarioContext.Set(SAP.JobPlanning.GetOrderNumber, "OrderNumber");
            _scenarioContext.Set(SAP.JobPlanning.GetNotificationNumber, "NotificationNumber");
        }

        [StepDefinition(@"The user release the work")]
        public void UserRealeaseTheWork()
        {
            SAP.JobPlanning.ReleaseWork(_scenarioContext.Get<string>("OrderNumber"));
        }

        [StepDefinition(@"The user validates that the work has been released")]
        public void UserValidatesWorkHasbeenReleased()
        {
            SAP.JobPlanning.ValidateWorkHasBeenReleased(_scenarioContext.Get<string>("OrderNumber"));
        }

        [StepDefinition(@"The user schedule the work")]
        public void UserScheduleTheWork()
        {
            SAP.JobPlanning.ScheduleWork(_scenarioContext.Get<string>("OrderNumber"));
        }

        [StepDefinition(@"The user validates that the work has been scheduled")]
        public void UserValidatesWorkHasbeenScheduled()
        {
            SAP.JobPlanning.ValidateWorkHasBeenScheduled();
        }

        [Given(@"The test data is set for a ""(.*)""")]
        public void GivenTheTestDataIsSetForA(string jsonFileName)
        {
            var file = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\Data\JobPlanning\" + jsonFileName + ".json");
            info = JsonConvert.DeserializeObject<JobPlanningInfo>(File.ReadAllText(file));
        }
    }
}
