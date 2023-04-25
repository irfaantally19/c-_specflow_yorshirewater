using Core_Framework.SAP;
using NUnit.Framework;
using SAP.Pages.Models;
using sapfewse;

namespace SAP.Pages.SAP_GUI
{
    public class StrategicPlanningPage : Abstract_SAP_S4_Page
    {
        //General elements
        private By StatusBar = By.Id("wnd[0]/sbar");                //Buttom status bar
        private By TitleBar = By.Name("titl", "GuiTitlebar");       //Title bar

        //Change Maintenance Strategies: Details Screen Fields and Buttons.
        private By Name = By.Name("V_T351-STRAT", "GuiCTextField");
        private By Description = By.Name("V_T351-KTEXT", "GuiTextField");
        private By ScheduleIndicator = By.Name("V_T351-TERMK", "GuiComboBox");
        private By StrategyUnit = By.Name("V_T351-ZEIEH", "GuiCTextField");
        private By CallHorizon = By.Name("V_T351-HORIZ", "GuiTextField");
        private By FactoryCalendar = By.Name("V_T351-FABKL", "GuiCTextField");
        private By AuthorizationGroup = By.Name("V_T351-AUTHGR", "GuiCTextField");
        private By PositionBtn = By.Name("VIM_POSI_PUSH", "GuiButton");
        private By CreatedMaintenanceStrategy = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351/ctxtV_T351-STRAT[0,0]");
        private By TableTreeControl = By.Id("wnd[0]/shellcont/shell");
        //Dailog box/Error box
        private By StrategyField = By.Name("SVALD-VALUE", "GuiCTextField");
        private By DailogBoxOkBtn = By.Id("wnd[1]/tbar[0]/btn[0]");
        //Maintenance Package fields
        private By Package1 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-ZAEHL[0,0]");
        private By Package2 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-ZAEHL[0,1]");
        private By Package3 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-ZAEHL[0,2]");
        private By CycleLength1 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtRMIPM-ZYKL1[1,0]");
        private By CycleLength2 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtRMIPM-ZYKL1[1,1]");
        private By CycleLength3 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtRMIPM-ZYKL1[1,2]");
        private By Unit1 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/ctxtV_T351P-ZEIEH[2,0]");
        private By Unit2 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/ctxtV_T351P-ZEIEH[2,1]");
        private By Unit3 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/ctxtV_T351P-ZEIEH[2,2]");
        private By MaintenanceCycleText1 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KTEX1[3,0]");
        private By MaintenanceCycleText2 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KTEX1[3,1]");
        private By MaintenanceCycleText3 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KTEX1[3,2]");
        private By CycleShortTextKey1 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KZYK1[4,0]");
        private By CycleShortTextKey2 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KZYK1[4,1]");
        private By CycleShortTextKey3 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KZYK1[4,2]");
        private By Hierarchy1 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-HIERA[5,0]");
        private By Hierarchy2 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-HIERA[5,1]");
        private By Hierarchy3 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-HIERA[5,2]");
        private By HierarchyShortTextKey1 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KTXHI[6,0]");
        private By HierarchyShortTextKey2 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KTXHI[6,1]");
        private By HierarchyShortTextKey3 = By.Id("wnd[0]/usr/tblSAPL0IP2TCTRL_V_T351P/txtV_T351P-KTXHI[6,2]");

        public StrategicPlanningPage(GuiSession session) : base(session)
        {
        }

        /********************************************Create time based maintenance strategy plan***************/

        //WJE20230327
        public void CreateNewMaintenanceStrategy(StrategicPlanningInfo info)
        {   
            WaitForSession();
            SendCommand("/nIP11");
            SendVKey(5); //New Entry
            TextFieldType(Name, info.MaintenanceStrategy);
            TextFieldType(Description, info.MaintenanceStrategy + " " + info.Description);
            SelectGuiComboBoxDropdownOptionByKey(ScheduleIndicator, info.ScheduleIndicator);
            TextFieldType(StrategyUnit, info.StrategyUnit);
            TextFieldType(CallHorizon, info.CallHorizon);
            TextFieldType(FactoryCalendar, info.FactoryCalendar);
            TextFieldType(AuthorizationGroup, info.AuthorizationGroup);
            SendVKey(11); //Ctrl + S (Save)

            //Check if record was saved successfully.
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue == "Data was saved", "Status not 'Data was saved' but " + actualValue + ".");
            SendVKey(12); //Cancel to return to main screen
        }

        //Seach Maintenance Strategy.
        public void SearchEntry(StrategicPlanningInfo info)
        {
            PressButton(PositionBtn);
            TextFieldType(StrategyField, info.MaintenanceStrategy);
            PressButton(DailogBoxOkBtn);
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }


        public void ValidateNewMaintenanceStrategy(StrategicPlanningInfo info)
        {
            SearchEntry(info);
            //Check if maintenance strategy was found.
            string actualValue = ((GuiCTextField)FindOne(CreatedMaintenanceStrategy)).Text;
            Assert.That(actualValue == info.MaintenanceStrategy, "Status not '" + info.MaintenanceStrategy + "' but " + actualValue + ".");
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

        /**********************************Create time base maintenance package*******************************/
        //WJE20230327
        public void CreateNewMaintenancePackage(StrategicPlanningInfo info)
        {
            WaitForSession();
            SendCommand("/nIP11");
            SearchEntry(info);
            SendVKey(9);    //Select (F9)
            TableTreeDoubleClick(TableTreeControl, "02", "Column1");
            SendVKey(5);    //New Entry

            TextFieldType(Package1, info.Package1);
            TextFieldType(Package2, info.Package2);
            TextFieldType(Package3, info.Package3);
            TextFieldType(CycleLength1, info.CycleLength1);
            TextFieldType(CycleLength2, info.CycleLength2);
            TextFieldType(CycleLength3, info.CycleLength3);
            TextFieldType(Unit1, info.Unit1);
            TextFieldType(Unit2, info.Unit2);
            TextFieldType(Unit3, info.Unit3);
            TextFieldType(MaintenanceCycleText1, info.MaintenanceCycleText1);
            TextFieldType(MaintenanceCycleText2, info.MaintenanceCycleText2);
            TextFieldType(MaintenanceCycleText3, info.MaintenanceCycleText3);
            TextFieldType(CycleShortTextKey1, info.CycleShortTextKey1);
            TextFieldType(CycleShortTextKey2, info.CycleShortTextKey2);
            TextFieldType(CycleShortTextKey3, info.CycleShortTextKey3);
            TextFieldType(Hierarchy1, info.Hierarchy1);
            TextFieldType(Hierarchy2, info.Hierarchy2);
            TextFieldType(Hierarchy3, info.Hierarchy3);
            TextFieldType(HierarchyShortTextKey1, info.HierarchyShortTextKey1);
            TextFieldType(HierarchyShortTextKey2, info.HierarchyShortTextKey2);
            TextFieldType(HierarchyShortTextKey3, info.HierarchyShortTextKey3);
            SendVKey(11); //Ctrl + S (Save)

            //System.Threading.Thread.Sleep(5000); //DebugOFF


        }
        public void ValidatesStrategyPackage(StrategicPlanningInfo info)
        {
            //Check if record was saved successfully.
            string actualValue = ((GuiStatusbar)FindOne(StatusBar)).Text;
            Assert.That(actualValue == "Data was saved", "Status not 'Data was saved' but " + actualValue + ".");
            SendVKey(12); //Cancel to return to main screen
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }


    }
}
