using TechTalk.SpecFlow;

namespace SAP.Steps.GUI
{
    [Binding]
    public class ScheduledMaintenancePlan : StepDefinition
    {
        private string MaintenanceNumber;

        public ScheduledMaintenancePlan(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            MaintenanceNumber = _scenarioContext.Get<string>("MaintenancePlanNumber");
        }


        [StepDefinition(@"The user Schedules a maintenance plan")]
        public void TheUserSchedulesAMaintenancePlan()
        {
            SAP.ScheduledMaintenancePlan.OpenScheduledMaintenancePlan(MaintenanceNumber);
            SAP.ScheduledMaintenancePlan.StartScheduledMaintenancePlan(MaintenanceNumber);
        }

        [StepDefinition(@"The user Releases the call")]
        public void TheUserReleasesTheCall()
        {
            SAP.ScheduledMaintenancePlan.StartReleaseCall();
        }

        [StepDefinition(@"The user Displays the call object and extracts the order number")]
        public void TheuserDisplaysTheCallObjectAndExtractsTheOrderNumber()
        {
            SAP.ScheduledMaintenancePlan.StartDisplayCallobject();
            SAP.DisplayAGOperational.ExtractOrderNumber();
        }

        [StepDefinition(@"The user completed the call")]
        public void TheuserCompletesTheCall()
        {
            SAP.ScheduledMaintenancePlan.CompleteCall(MaintenanceNumber);
        }
    }
}
