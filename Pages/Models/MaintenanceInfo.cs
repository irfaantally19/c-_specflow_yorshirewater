using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Pages.Models
{
    public class MaintenanceInfo
    {
        public string MaintenancePlanCategory { get; set; }
        public string Strategy { get; set; }
        public string MaintenancePlan { get; set; }
        public string MaintenanceItem { get; set; }
        public string Equipment { get; set; }
        public string OrderType { get; set; }
        public string MaintActivityType { get; set; }
        public bool DoNotRelImmediately { get; set; }
        public bool FuncLocTaskList { get; set; }
        public bool EquipTaskList { get; set; }
        public string Group { get; set; }
        public string TaskListDescription { get; set; }
        public string CallHorizonNumber { get; set; }
        public string CallHorizonUnit { get; set; }
        public string SchedulingPeriodNumber { get; set; }
        public string SchedulingPeriodUnit { get; set; }
        public bool CompletionRequirement { get; set; }
        public string MaintenancePlanNumber { get; set; }
        public string MaintPlannerGroup { get; set; }

    }
}
