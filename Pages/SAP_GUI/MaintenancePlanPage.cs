using Core_Framework.SAP;
using NUnit.Framework;
using SAP.Pages.Models;
using sapfewse;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SAP.Pages.SAP_GUI
{
    public class MaintenancePlanPage : Abstract_SAP_S4_Page
    {
        // global variables
        private string maintenancePlanNumber;
        //General elements
        private By StatusBar = By.Id("wnd[0]/sbar");                //Buttom status bar
        private By TitleBar = By.Name("titl", "GuiTitlebar");       //Title bar
        //IP01
        private By MaintenancePlanCategory = By.Name("RMIPM-MPTYP", "GuiComboBox");
        private By Strategy = By.Name("RMIPM-WSTRA", "GuiCTextField");
        private By MaintenancePlan = By.Name("RMIPM-WPTXT", "GuiTextField");
        private By MaintenanceItem = By.Name("RMIPM-PSTXT", "GuiTextField");
        private By Equipment = By.Name("RIWO1-EQUNR", "GuiCTextField");
        private By OrderType = By.Name("RMIPM-AUART", "GuiCTextField");
        private By MaintActivityType = By.Name("RMIPM-ILART", "GuiCTextField");
        private By DoNotRelImmediately = By.Name("MPOS-NO_AUFRELKZ", "GuiCheckBox");
        private By SelectTaskListBtn = By.Name("ARBEITSPLAN_S", "GuiButton");
        private By FuncLocTaskList = By.Name("PN_IFLO", "GuiCheckBox");
        private By EquipTaskList = By.Name("PN_EQUI", "GuiCheckBox");
        private By Group = By.Name("PN_PLNNR-LOW", "GuiCTextField");
        private By TaskListDescription = By.Name("RMIPM-PLANTEXT", "GuiTextField");
        private By MaintPlanScheduleParameters = By.Name("T\\02", "GuiTab");
        private By CallHorizonNumber = By.Name("RMIPM-HORIZ", "GuiTextField");
        private By CallHorizonUnit = By.Name("RMIPM-HORIZ_QUALIFIER", "GuiCTextField");
        private By SchedulingPeriodNumber = By.Name("RMIPM-ABRHO", "GuiTextField");
        private By SchedulingPeriodUnit = By.Name("RMIPM-HUNIT", "GuiCTextField");
        private By CompletionRequirement = By.Name("RMIPM-CALL_CONFIRM", "GuiCheckBox");
        private By StartOfCycle = By.Name("RMIPM-STADT", "GuiCTextField");
        private By TimeKeyDate = By.Name("RMIPM-STICH", "GuiRadioButton");
        //IP02
        private By MaintenancePlanNumber = By.Name("RMIPM-WARPL", "GuiCTextField");
        private By CreateMoreItemBtn1 = By.Name("ITEM_CREATE", "GuiButton");
        private By MaintenancePlannerGroup = By.Name("RMIPM-WPGRP", "GuiCTextField");
        private By CreateMoreItemBtn2 = By.Name("WARTPOS_CREATE", "GuiButton");
        private By ItemsTable = By.Name("SAPLIWP3TCTRL_0220", "GuiTableControl");
        private By ItemTab = By.Name("T\\11", "GuiTab");
        //Change maintenance popup
        private By PopUpMessage = By.Name("SPOP-TEXTLINE1", "GuiTextField");
        private By PopUpYesBtn = By.Name("SPOP-OPTION1", "GuiButton");
        private By PopUpNoBtn = By.Name("SPOP-OPTION2", "GuiButton");



        public MaintenancePlanPage(GuiSession session) : base(session)
        {
        }

        public string SetMaintenancePlanNumber()
        {
            //store value of maintenance plan in global variable
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            string[] numbers = Regex.Split(actualValue, @"\D+");
            maintenancePlanNumber = numbers[1];
            Console.WriteLine("Maintenance plan no: " + maintenancePlanNumber);
            return maintenancePlanNumber;
        }

        public string GetMaintenancePlanNumber()
        {
            return maintenancePlanNumber;
        }

        public string CreateSingleItemMaintenancePlan(MaintenanceInfo info)
        {
            WaitForSession();
            SendCommand("/nIP01");
            SelectGuiComboBoxDropdownOptionByKey(MaintenancePlanCategory, info.MaintenancePlanCategory);
            TextFieldType(Strategy, info.Strategy);
            SendVKey(0);    //Enter
            TextFieldType(MaintenancePlan, info.MaintenancePlan);
            TextFieldType(MaintenanceItem, info.MaintenanceItem);
            SendVKey(0);    //Enter
            TextFieldType(Equipment, info.Equipment);
            SendVKey(0);    //Enter
            TextFieldType(OrderType, info.OrderType);
            SendVKey(0);    //Enter
            TextFieldType(MaintActivityType, info.MaintActivityType);
            SetCheckbox(DoNotRelImmediately, info.DoNotRelImmediately);
            PressButton(SelectTaskListBtn);
            SetCheckbox(FuncLocTaskList, info.FuncLocTaskList);
            SetCheckbox(EquipTaskList, info.EquipTaskList);
            TextFieldType(Group, info.Group);
            SendVKey(8);    //Execute F8
            ConfirmFieldContents(TaskListDescription, "GuiTextField", info.TaskListDescription);
            SelectTab(MaintPlanScheduleParameters);
            TextFieldType(CallHorizonNumber, info.CallHorizonNumber);
            TextFieldType(CallHorizonUnit, info.CallHorizonUnit);
            TextFieldType(SchedulingPeriodNumber, info.SchedulingPeriodNumber);
            TextFieldType(SchedulingPeriodUnit, info.SchedulingPeriodUnit);
            SetCheckbox(CompletionRequirement, info.CompletionRequirement);
            SetRadioBtn(TimeKeyDate);
            TextFieldType(StartOfCycle, GetSelectedDate("Today"));
            SendVKey(11); //Ctrl + S (Save)
            return SetMaintenancePlanNumber();

            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

        public void ValidateSingleItemMaintenancePlan(string maintPlanNumber)
        {
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue == "Maintenance plan " + maintPlanNumber + " created", "Status not 'Maintenance plan " + maintPlanNumber + " created' but '" + actualValue + "'.");
            SendVKey(12); //Cancel to return to main screen
        }

        // Note: to create a multi item maint plan, a single item maint plan needs to be created first
        public void CreateMultiItemMaintenancePlan(MaintenanceInfo info, string maintPlanNumber)
        {
            WaitForSession();
            SendCommand("/nIP02");
            TextFieldType(MaintenancePlanNumber, maintPlanNumber);
            SendVKey(0);    //Enter
            // have 2 different create more item button: 1. when there is only 1 item 2. when there are more than 1 item in the list
            if(IsButtonPresent(CreateMoreItemBtn1) == true)
            {
                PressButton(CreateMoreItemBtn1);
            }
            else
            {
                PressButton(CreateMoreItemBtn2);
            }
            TextFieldType(MaintenancePlan, info.MaintenancePlan);
            TextFieldType(MaintenanceItem, info.MaintenanceItem);
            TextFieldType(Equipment, info.Equipment);
            SendVKey(0);    //Enter
            TextFieldType(OrderType, info.OrderType);
            SendVKey(0);    //Enter
            TextFieldType(MaintActivityType, info.MaintActivityType);
            TextFieldType(MaintenancePlannerGroup, info.MaintPlannerGroup);
            SetCheckbox(DoNotRelImmediately, info.DoNotRelImmediately);
            PressButton(SelectTaskListBtn);
            SetCheckbox(FuncLocTaskList, info.FuncLocTaskList);
            SetCheckbox(EquipTaskList, info.EquipTaskList);
            TextFieldType(Group, info.Group);
            SendVKey(8);    //Execute F8
            ConfirmFieldContents(TaskListDescription, "GuiTextField", info.TaskListDescription);
            SendVKey(11); //Ctrl + S (Save)
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

        public void CreateMultiItemMaintenancePlanMECH(MaintenanceInfo info, string maintPlanNumber)
        {
            WaitForSession();
            SendCommand("/nIP02");
            // entering maintenanceplan number
            TextFieldType(MaintenancePlanNumber, maintPlanNumber);
            SendVKey(0);    //Enter
            // have 2 different create more item button: 1. when there is only 1 item 2. when there are more than 1 item in the list
            if (IsButtonPresent(CreateMoreItemBtn1) == true)
            {
                PressButton(CreateMoreItemBtn1);
            }
            else
            {
                PressButton(CreateMoreItemBtn2);
            }
            TextFieldType(MaintenancePlan, info.MaintenancePlan);
            TextFieldType(MaintenanceItem, info.MaintenanceItem);
            TextFieldType(Equipment, info.Equipment);
            SendVKey(0);    //Enter
            TextFieldType(OrderType, info.OrderType);
            SendVKey(0);    //Enter
            TextFieldType(MaintActivityType, info.MaintActivityType);
            TextFieldType(MaintenancePlannerGroup, info.MaintPlannerGroup);
            SetCheckbox(DoNotRelImmediately, info.DoNotRelImmediately);
            PressButton(SelectTaskListBtn);
            SetCheckbox(FuncLocTaskList, info.FuncLocTaskList);
            SetCheckbox(EquipTaskList, info.EquipTaskList);
            TextFieldType(Group, info.Group);
            SendVKey(8);    //Execute F8
            ConfirmFieldContents(TaskListDescription, "GuiTextField", info.TaskListDescription);
            SelectTab(MaintPlanScheduleParameters);
            TextFieldType(CallHorizonNumber, info.CallHorizonNumber);
            TextFieldType(CallHorizonUnit, info.CallHorizonUnit);
            TextFieldType(SchedulingPeriodNumber, info.SchedulingPeriodNumber);
            TextFieldType(SchedulingPeriodUnit, info.SchedulingPeriodUnit);
            SetCheckbox(CompletionRequirement, info.CompletionRequirement);
            SetRadioBtn(TimeKeyDate);
            TextFieldType(StartOfCycle, GetSelectedDate("Today"));
            SendVKey(11); //Ctrl + S (Save)
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

        public void ValidateMultiItemMaintenancePlan(MaintenanceInfo info, string maintPlanNumber)
        {
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue == "Maintenance plan " + maintPlanNumber + " changed", "Status not 'Maintenance plan " + maintPlanNumber + " changed' but '" + actualValue + "'.");
            SendVKey(12); //Cancel to return to main screen
        }

        public void AmendMultiItemMaintenancePlan(MaintenanceInfo info, string maintPlanNumber)
        {
            WaitForSession();
            SendCommand("/nIP02");
            TextFieldType(MaintenancePlanNumber, maintPlanNumber);
            SendVKey(0);    //Enter
            // selects first row in multi items
            SelectGuiTableControlRow(ItemsTable, 0);
            SelectTab(ItemTab);
            TextFieldType(MaintenancePlan, info.MaintenancePlan);
            TextFieldType(MaintenanceItem, info.MaintenanceItem);
            SendVKey(0);    //Enter
            TextFieldType(Equipment, info.Equipment);
            SendVKey(0);    //Enter
            //if pop-up present -> click yes
            if (IsTextFieldPresent(PopUpMessage))
            {
                PressButton(PopUpYesBtn);
            }
            TextFieldType(OrderType, info.OrderType);
            SendVKey(0);    //Enter
            TextFieldType(MaintActivityType, info.MaintActivityType);
            TextFieldType(MaintenancePlannerGroup, info.MaintPlannerGroup);
            SetCheckbox(DoNotRelImmediately, info.DoNotRelImmediately);
            SendVKey(11); //Ctrl + S (Save)
        }

        public void AmendMultiItemMaintenancePlanMECH(MaintenanceInfo info, string maintPlanNumber)
        {
            WaitForSession();
            SendCommand("/nIP02");
            TextFieldType(MaintenancePlanNumber, maintPlanNumber);
            SendVKey(0);    //Enter
            // selects first row in multi items
            SelectGuiTableControlRow(ItemsTable, 0);
            SelectTab(ItemTab);
            TextFieldType(MaintenancePlan, info.MaintenancePlan);
            TextFieldType(MaintenanceItem, info.MaintenanceItem);
            SendVKey(0);    //Enter
            TextFieldType(Equipment, info.Equipment);
            SendVKey(0);    //Enter
            //if pop-up present -> click yes
            if (IsTextFieldPresent(PopUpMessage))
            {
                PressButton(PopUpYesBtn);
            }
            TextFieldType(OrderType, info.OrderType);
            SendVKey(0);    //Enter
            TextFieldType(MaintActivityType, info.MaintActivityType);
            SetCheckbox(DoNotRelImmediately, info.DoNotRelImmediately);
            SendVKey(11); //Ctrl + S (Save)
        }

        public void ValidateAmendingMultiItemMaintenancePlan(string maintPlanNumber)
        {
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue.Contains(maintPlanNumber + " changed") == true, "Status does not contains " + maintPlanNumber + " changed' but status is '" + actualValue + "'.");
            SendVKey(12); //Cancel to return to main screen
        }
    }
}