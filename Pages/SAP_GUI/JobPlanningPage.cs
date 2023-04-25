using Core_Framework.SAP;
using NUnit.Framework;
using SAP.Pages.Models;
using sapfewse;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SAP.Pages.SAP_GUI
{
    public class JobPlanning : Abstract_SAP_S4_Page
    {
        // global variables
        private string orderNumber;
        private string notificationNumber;
        //General elements
        private By StatusBar = By.Id("wnd[0]/sbar");                //Buttom status bar
        private By TitleBar = By.Name("titl", "GuiTitlebar");       //Title bar
        //IW49
        private By Order = By.Name("AUFNR-LOW", "GuiCTextField");
        private By OrderType = By.Name("AUART-LOW", "GuiCTextField");
        private By ChangeDisplay = By.Name("btn[17]", "GuiButton");
        private By OrderListShell = By.Name("shell", "GuiShell");
        private By OperationsTab = By.Name("VGUE", "GuiTab");
        private By OperationsTable = By.Name("SAPLCOVGTCTRL_3010", "GuiTableControl");
        private By OperationStatusBtn = By.Name("BTN_STAV", "GuiButton");
        private By SOPRadioBtn = By.Id("wnd[0]/usr/tabsTABSTRIP_0300/tabpANWS/ssubSUBSCREEN:SAPLBSVA:0302/tblSAPLBSVATC_E/radJ_STMAINT-ANWS[0,2]");
        private By ReleaseBtn = By.Name("btn[25]", "GuiButton");
        private By ScheduleBtn = By.Name("btn[28]", "GuiButton");
        private By SystemStatus = By.Name("CAUFVD-STTXT", "GuiTextField");
        //IW31 Create Order
        private By OrderType_CO = By.Name("AUFPAR-PM_AUFART", "GuiCTextField");
        private By FuncLoc_CO = By.Name("CAUFVD-TPLNR", "GuiCTextField");
        private By Equipment_CO = By.Name("CAUFVD-EQUNR", "GuiCTextField");
        private By OperationDescription = By.Name("CAUFVD-KTEXT", "GuiTextField");
        private By BasicFinishDate = By.Name("CAUFVD-GLTRP", "GuiCTextField");




        public JobPlanning(GuiSession session) : base(session)
        {
        }

        public void SetOrderNumber()
        {
            //store value of order number in global variable
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            string[] numbers = Regex.Split(actualValue, @"\D+");
            orderNumber = numbers[1];
        }

        public string GetOrderNumber()
        {
            return orderNumber;
        }

        public void SetNotificationNumber()
        {
            //store value of notification number in global variable
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            string[] numbers = Regex.Split(actualValue, @"\D+");
            notificationNumber = numbers[2];
        }

        public string GetNotificationNumber()
        {
            return notificationNumber;
        }

        public void SOPAndCompletePlanningOperation(JobPlanningInfo info, string orderNumber)
        {
            WaitForSession();
            //if scenariocontext OrderNumber is empty -> create order then use new order number
            if (string.IsNullOrEmpty(orderNumber))
            {
                CreateOrder(info);
                orderNumber = this.orderNumber;
            }
            SendCommand("/nIW49");
            TextFieldType(Order, orderNumber);
            TextFieldType(OrderType, info.OrderType);
            SendVKey(8);    //Execute F8
            PressButton(ChangeDisplay);
            System.Threading.Thread.Sleep(3000); // have to put an explicit wait as we need to wait for the order to be processed to be perfom the next steps
            // double click on the order number
            DoubleClickGridViewCell(OrderListShell, 0, "AUFNR");
            //navigate to operations tab
            SelectTab(OperationsTab);
            //select first row of operations table
            SelectGuiTableControlRow(OperationsTable, 0);
            //click on set status button
            PressButton(OperationStatusBtn);
            //select SOP radio button
            SetRadioBtn(SOPRadioBtn);
            SendVKey(3);    //Continue F3
            SendVKey(11); //Ctrl + S (Save)
            //verified order and store notification number
            ValidateOrderAndStoreNotificationNumber(orderNumber);
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

        public void ValidateWorkHasBeenReleased(string orderNumber)
        {
            //verified order has been released in the notification status at the bottom
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue == "Order " + orderNumber + " will be released after update", "Status not 'Order " + orderNumber + " will be released after update" + "' but '" + actualValue + "'.");
            //verified the status has changed in the system status at the top 
            string systemStatusText = ((GuiTextField)FindOne(SystemStatus)).Text;
            Assert.That(systemStatusText.Contains("REL") == true, "Status is not RELEASED" + "' but system status is '" + systemStatusText + "'.");
        }

        public void ValidateWorkHasBeenScheduled()
        {
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue == "Scheduling carried out (see log)", "Status not 'Scheduling carried out (see log)" + "' but '" + actualValue + "'.");
        }

        public void ValidateOrderAndStoreNotificationNumber(string orderNumber)
        {
            SetNotificationNumber();
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue == "Order " + orderNumber + " saved with notification " + notificationNumber, "Status not 'Order " + orderNumber + " saved with notification " + notificationNumber + "' but '" + actualValue + "'.");   
        }

        public void CreateOrder(JobPlanningInfo info)
        {
            WaitForSession();
            SendCommand("/nIW31");
            TextFieldType(OrderType_CO, info.OrderType);
            TextFieldType(FuncLoc_CO, info.FuncLoc);
            TextFieldType(Equipment_CO, info.Equipment);
            SendVKey(0);    //Enter
            TextFieldType(OperationDescription, "Test");
            TextFieldType(BasicFinishDate, GetSelectedDate("NextYear"));
            SelectTab(OperationsTab);
            //select first row of operations table
            SelectGuiTableControlRow(OperationsTable, 0);
            //click on set status button
            PressButton(OperationStatusBtn);
            //select SOP radio button
            SetRadioBtn(SOPRadioBtn);
            SendVKey(3);    //Continue F3
            SendVKey(11); //Ctrl + S (Save)
            SetOrderNumber();
            SendVKey(12); //return to main screen
        }

        public void ReleaseWork(string orderNumber)
        {
            WaitForSession();
            SendCommand("/nIW49");
            TextFieldType(Order, orderNumber);
            SendVKey(8);    //Execute F8
            PressButton(ChangeDisplay);
            System.Threading.Thread.Sleep(3000); // have to put an explicit wait as we need to wait for the order to be processed to be perfom the next steps
            // double click on the order number
            DoubleClickGridViewCell(OrderListShell, 0, "AUFNR");
            //release order
            PressButton(ReleaseBtn);
        }

        public void ScheduleWork(string orderNumber)
        {
            WaitForSession();
            SendCommand("/nIW49");
            TextFieldType(Order, orderNumber);
            SendVKey(8);    //Execute F8
            PressButton(ChangeDisplay);
            // double click on the order number
            DoubleClickGridViewCell(OrderListShell, 0, "AUFNR");
            //schedule order
            PressButton(ScheduleBtn);
        }
    }
}