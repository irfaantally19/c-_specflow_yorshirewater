using SAP.Applications;
using SAP.Pages.SAP_GUI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SAP.Steps.GUI
{
    [Binding]
    public class GeneralStepDefs : StepDefinition
    {
        WindowsActions WindowsActions { get; set; }

        public GeneralStepDefs(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [StepDefinition(@"The user logs out")]
        public void ThenTheUserLogsOut()
        {
            Core.SAPSupport.CloseSAP();
        }


        [StepDefinition(@"SAP is open and logged in")]
        public void GivenSAPIsOpenAndLoggedIn()
        {
            Core.SAPSupport = new Core_Framework.SAP.SAPSupport();
            Core.Desktop = new Core_Framework.Desktop.CodedUI.UISupport();
            Thread acceptThread = new Thread(AcceptSAPPopup);
            acceptThread.Start();

            SAP = new SAPS4_Application(Core.SAPSupport
                .GetSession("S/4 HANA QAS (S2Q)"));

            acceptThread.Join();
        }

        public void AcceptSAPPopup()
        {
            try
            {
                WindowsActions = new WindowsActions(Core.Desktop.GetAutomationClass());
                WindowsActions.AcceptSAPLogion();
            }
            catch (Exception)
            {
                Console.WriteLine("Access Popup not found - assuming not required");
            }

        }
    }
}
