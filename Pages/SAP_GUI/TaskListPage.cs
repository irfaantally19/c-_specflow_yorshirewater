using Core_Framework.SAP;
using NUnit.Framework;
using SAP.Pages.Models;
using sapfewse;

namespace SAP.Pages.SAP_GUI
{
    public class TaskListPage : Abstract_SAP_S4_Page
    {
        //General elements
        private By StatusBar = By.Id("wnd[0]/sbar");                //Buttom status bar
        private By TitleBar = By.Name("titl", "GuiTitlebar");       //Title bar
        //Error/Information message box and button
        private By TaskListGroup = By.Name("RC271-PLNNR", "GuiCTextField");
        private By PlanningPlant = By.Name("PLKOD-WERKS", "GuiCTextField");
        private By TaskListHeader = By.Name("PLKOD-KTEXT", "GuiTextField");
        private By WorkCentre = By.Name("RCR01-ARBPL", "GuiCTextField");
        private By Plant = By.Name("RCR01-WERKS", "GuiCTextField");
        private By Usage = By.Name("PLKOD-VERWE", "GuiCTextField");
        private By PlannerGroup = By.Name("PLKOD-VAGRP", "GuiCTextField");
        private By OverallStatus = By.Name("PLKOD-STATU", "GuiCTextField");
        private By MaintenanceStrategy = By.Name("PLKOD-STRAT", "GuiCTextField");
        private By TaskTable = By.Name("SAPLCPDITCTRL_3200", "GuiTableControl");
        private By Work_1 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/txtPLPOD-ARBEI[7,0]");
        private By WorkUnit_1 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/ctxtPLPOD-ARBEH[8,0]");
        private By Number_1 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/txtPLPOD-ANZZL[9,0]");
        private By Duration_1 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/txtPLPOD-DAUNO[10,0]");
        private By DurationUnit_1 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/ctxtPLPOD-DAUNE[11,0]");
        private By CalculationKey_1 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/ctxtPLPOD-INDET[12,0]");
        private By StandardTextKey_1 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/ctxtPLPOD-KTSCH[17,0]");

        private By Work_2 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/txtPLPOD-ARBEI[7,1]");
        private By WorkUnit_2 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/ctxtPLPOD-ARBEH[8,1]");
        private By Number_2 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/txtPLPOD-ANZZL[9,1]");
        private By Duration_2 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/txtPLPOD-DAUNO[10,1]");
        private By DurationUnit_2 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/ctxtPLPOD-DAUNE[11,1]");
        private By CalculationKey_2 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/ctxtPLPOD-INDET[12,1]");
        private By StandardTextKey_2 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3400/ctxtPLPOD-KTSCH[17,1]");

        //Row 0010
        private By MntPackBtn = By.Name("TEXT_DRUCKTASTE_WP", "GuiButton");
        private By CheckBox_11 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3600/chkRIHSTRAT-MARK01[3,0]");
        private By CheckBox_12 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3600/chkRIHSTRAT-MARK02[4,0]");
        private By CheckBox_13 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3600/chkRIHSTRAT-MARK03[5,0]");
        //Row 0020
        private By CheckBox_21 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3600/chkRIHSTRAT-MARK01[3,1]");
        private By CheckBox_22 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3600/chkRIHSTRAT-MARK02[4,1]");
        private By CheckBox_23 = By.Id("wnd[0]/usr/tblSAPLCPDITCTRL_3600/chkRIHSTRAT-MARK03[5,1]");

        public TaskListPage(GuiSession session) : base(session)
        {
        }

        //WJE20230329
        public void CreateGeneralTaskList(TaskListInfo info)
        {
            WaitForSession();
            SendCommand("/nIA05");
            //Create general task
            TextFieldType(TaskListGroup, info.TaskListGroup);
            SendVKey(5);    //Refresh (F5)
            SendVKey(6);    //Create a task F6
            TextFieldType(PlanningPlant, info.PlanningPlant);
            TextFieldType(TaskListHeader, info.TaskListHeader);
            TextFieldType(WorkCentre, info.WorkCentre);
            TextFieldType(Plant, info.PlanningPlant);
            TextFieldType(Usage, info.Usage);
            TextFieldType(PlannerGroup, info.PlannerGroup);
            TextFieldType(OverallStatus, info.OverallStatus);
            TextFieldType(MaintenanceStrategy, info.MaintenanceStrategy);
            SendVKey(11); //Save (Ctrl + S)

            //Create general operation
            SendVKey(5);    //Refresh (F5)
            TableCellSelect(TaskTable, info.TaskListHeader);
            SendVKey(2);    //Choose (F2)
            TextFieldType(Work_1, info.Work);
            TextFieldType(WorkUnit_1, info.Unit);
            TextFieldType(Number_1, info.No);
            TextFieldType(Duration_1, info.Duration);
            TextFieldType(DurationUnit_1, info.Unit);
            TextFieldType(CalculationKey_1, info.CalculationKey);
            TextFieldType(StandardTextKey_1, info.StandardTextKey);
            //Maintenance Package Overview
            PressButton(MntPackBtn);
            SetCheckbox(CheckBox_11, true);
            //SetCheckbox(CheckBox_12, true);
            //SetCheckbox(CheckBox_13, true);
            SendVKey(11); //Save (Ctrl + S)
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }


        public void AddGeneralOperation(TaskListInfo info)
        {
            WaitForSession();
            SendCommand("/nIA05");
            TextFieldType(TaskListGroup, info.TaskListGroup);
            //Create general operation
            SendVKey(0);    //Enter
            TableCellSelect(TaskTable, info.TaskListHeader);
            SendVKey(2);    //Choose (F2)
            TextFieldType(Work_2, info.Work);
            TextFieldType(WorkUnit_2, info.Unit);
            TextFieldType(Number_2, info.No);
            TextFieldType(Duration_2, info.Duration);
            TextFieldType(DurationUnit_2, info.Unit);
            TextFieldType(CalculationKey_2, info.CalculationKey);
            TextFieldType(StandardTextKey_2, info.StandardTextKey);
            //Maintenance Package Overview
            PressButton(MntPackBtn);
            //SetCheckbox(CheckBox_21, true);
            SetCheckbox(CheckBox_22, true);
            //SetCheckbox(CheckBox_23, true);
            SendVKey(11); //Save (Ctrl + S)
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

        public void ValidateGeneralTaskList(TaskListInfo info)
        {
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue == "General task list " + info.TaskListGroup + " saved", "Status not 'General task list " + info.TaskListGroup + " saved' but '" + actualValue + "'.");
            SendVKey(12); //Cancel to return to main screen
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

    }
}
