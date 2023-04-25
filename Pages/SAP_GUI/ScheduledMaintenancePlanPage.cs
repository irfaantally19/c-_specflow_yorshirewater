using System.Threading;
using Core_Framework.SAP;
using NUnit.Framework;
using sapfewse;

namespace SAP.Pages.SAP_GUI
{
    public class ScheduledMaintenancePlanPage : Abstract_SAP_S4_Page
    {
        //nPI10
        private By MaintenancePlan = By.Id("wnd[0]/usr/ctxtRMIPM-WARPL");

        private By Start = By.Id("wnd[0]/tbar[1]/btn[9]");
        private By StatInCycle = By.Id("wnd[0]/tbar[1]/btn[31]");
        private By ManualCall = By.Id("wnd[0]/tbar[1]/btn[18]");
        private By ScheduleOverviewList = By.Id("wnd[0]/tbar[1]/btn[37]");
        private By Info = By.Id("wnd[1]/usr/txtMESSTXT1");
        private By Table = By.Name("SAPLIWP3TCTRL_0121", "GuiTableControl");
        private By CompleteCallbtn = By.Name("RUECKMELDEN", "GuiButton");
        private By Back = By.Name("btn[3]", "GuiButton");
        private By StatusPane = By.Name("btn[3]", "GuiButton");

        //Start
        private By StartDate = By.Id("wnd[1]/usr/ctxtRMIPM-STADT");
        private By ReleaseCall = By.Name("%#AUTOTEXT001", "GuiButton");
        private By DisplayCallobject = By.Name("CALLS", "GuiButton");
        private By SchedulingStatus = By.Name("TERMFELD2", "GuiTextField");

        //Start in cycle
        private By CompletionDate = By.Id("wnd[1]/usr/ctxtRMIPM-LRMDT");
        private By CompletionTime = By.Id("wnd[1]/usr/ctxtRMIPM-CONF_TIME");
        private By SelectPackage = By.Id("wnd[1]/usr/btn%#AUTOTEXT001");


        public ScheduledMaintenancePlanPage(GuiSession session) : base(session)
        {
        }

        /// <summary>
        /// Open the schedule maintenance plan screen
        /// </summary>
        /// <param name="MaintenancePlanNumber"></param>
        public void OpenScheduledMaintenancePlan(string MaintenancePlanNumber)
        {
            WaitForSession();
            SendCommand("/nIP10");
            TextFieldType(MaintenancePlan, MaintenancePlanNumber);
            SendVKey(00);
        }

        /// <summary>
        /// Schedules the plan and asserts the calls
        /// </summary>
        /// <param name="MaintenancePlanNumber"></param>
        public void StartScheduledMaintenancePlan(string MaintenancePlanNumber)
        {
            SendVKey(9);
            PressButton(ContinueButton);
            Assert.That(((GuiTextField)FindOne(SchedulingStatus)).Text.Contains("Save to call"));
            PressButton(SaveBtn);
            if (IsButtonPresent(ContinueButton))
            {
                PressButton(ContinueButton);
            }
            // Assert.That(((GuiTextField)FindOne(Statusbar)).Text.Contains("Maintenance plan" + MaintenancePlanNumber + " changed"));
            TextFieldType(MaintenancePlan, MaintenancePlanNumber);
            //TODO
            Thread.Sleep(3000); // Not sure of a better way to handle this
            SendVKey(00);
            Assert.That(((GuiTextField)FindOne(SchedulingStatus)).Text.Contains("Called"));
        }

        /// <summary>
        /// Displays the call objects
        /// </summary>
        public void StartDisplayCallobject()
        {
            PressButton(DisplayCallobject);
        }

        /// <summary>
        /// Release the call
        /// </summary>
        public void StartReleaseCall()
        {
            PressButton(ReleaseCall);
            Assert.That(((GuiTextField)FindOne(Info)).Text.Contains("No line selected"));
            PressButton(ContinueButton);
            SelectGuiTableControlRow(Table, 0);
            PressButton(ReleaseCall);
            Assert.That(((GuiTextField)FindOne(Info)).Text.Contains("Release not possible as MaintPlan already"));
            PressButton(ContinueButton);
        }

        /// <summary>
        /// Completes the call
        /// </summary>
        public void CompleteCall(string MaintenancePlanNumber)
        {
            PressButton(Back);
            PressButton(CompleteCallbtn);
            PressButton(ContinueButton);
            Assert.That(((GuiTextField)FindOne(SchedulingStatus)).Text.Contains("Complete"));
            PressButton(SaveBtn);
            //Assert.That(((GuiTextField)FindOne(StatusPane)).Text.Contains("Maintenance plan scheduled" + MaintenancePlanNumber + " scheduled"));
        }

    }
}
