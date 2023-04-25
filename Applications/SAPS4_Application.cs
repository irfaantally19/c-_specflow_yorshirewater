using SAP.Pages.SAP_GUI;
using sapfewse;

namespace SAP.Applications
{
    public class SAPS4_Application
    {
        public static string ApplicationPath { get; set; } = @"C:\Program Files (x86)\SAP\NWBC70\NWBC.exe";

        public StrategicPlanningPage StrategicPlanningPage { get; set; }
        public TaskListPage TaskListPage { get; set; }
        public MaintenancePlanPage MaintenancePlanPage { get; set; }
        public ReviewOrderListPage ReviewOrderListPage { get; set; }
        public ScheduledMaintenancePlanPage ScheduledMaintenancePlan { get; set; }
        public DisplayAGOperationalPage DisplayAGOperational { get; set; }
        public MRSPlaningBoardPage MRSPlaningBoardPage { get; set; }
        public MRSResourcePlaningPage MRSResourcePlaningPage { get; set; }
        public JobPlanning JobPlanning { get; set; }


        public SAPS4_Application(GuiSession SapSession)
        {
            StrategicPlanningPage = new StrategicPlanningPage(SapSession);
            TaskListPage = new TaskListPage(SapSession);
            MaintenancePlanPage = new MaintenancePlanPage(SapSession);
            ReviewOrderListPage = new ReviewOrderListPage(SapSession);
            ScheduledMaintenancePlan = new ScheduledMaintenancePlanPage(SapSession);
            DisplayAGOperational = new DisplayAGOperationalPage(SapSession);
            MRSPlaningBoardPage = new MRSPlaningBoardPage(SapSession);
            MRSResourcePlaningPage = new MRSResourcePlaningPage(SapSession);
            JobPlanning = new JobPlanning(SapSession);
        }

    }
}



