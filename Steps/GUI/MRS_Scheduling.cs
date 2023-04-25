using TechTalk.SpecFlow;

namespace SAP.Steps.GUI
{
    [Binding]
    public class MRS_Scheduling : StepDefinition
    {

        public MRS_Scheduling(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }


        [StepDefinition(@"Schedule MRS work order")]
        public void ThenTheUserLogsOut()
        {
            SAP.MRSPlaningBoardPage.ExecuteMRSPlanning(null, _scenarioContext.Get<string>("OrderNumber"));
            SAP.MRSResourcePlaningPage.AssignTaskToTechnition();
        }

        [StepDefinition(@"Block and unblock time for a technician")]
        public void ThenBlockAndUnblockTimeForATechnician()
        {
            SAP.MRSPlaningBoardPage.ExecuteMRSPlanning(null, _scenarioContext.Get<string>("OrderNumber"));
            SAP.MRSResourcePlaningPage.BlockAndUnblockTimeForATechnician();
        }
    }
}
