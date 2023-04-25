using Core_Framework.SAP;
using sapfewse;

namespace SAP.Pages.SAP_GUI
{
    public class MRSResourcePlaningPage : Abstract_SAP_S4_Page
    {
        //General elements
        private By Assignment = By.Name("btn[6]", "GuiButton");
        private By TimeAllocation = By.Name("btn[6]", "GuiButton");
        //need to find locator for shell table
        private By Resource = By.Name("", "");
        private By Order = By.Name("", "");
        private By Resourcedpd = By.Name("PB_F4_RESOURCE", "GuiButton");

        private By Resourcename = By.Id("wnd[1]/usr/chk[1,3]");
        private By Description = By.Name("GS_COMM_DETAILS-DESCRIPTION", "GuiTextField");
        private By Type = By.Name("GS_COMM_DETAILS-TIMESPEC_TYPE", "GuiComboBox");
        private By StartDate = By.Name("GS_COMM_DETAILS-BEGDA", "GuiCTextField");
        private By StartTime = By.Name("GS_COMM_DETAILS-BEG_UZEIT", "GuiCTextField");
        private By EndDate = By.Name("GS_COMM_DETAILS-ENDDA", "GuiCTextField");
        private By EndTime = By.Name("GS_COMM_DETAILS-END_UZEIT", "GuiCTextField");
        private By Create = By.Name("GS_COMM_PBO-PB_COMMIT", "GuiButton");
        private By Close = By.Name("PB_CANCEL", "GuiButton");
        private By Deletebtn = By.Name("btn[14]", "GuiButton");


        public MRSResourcePlaningPage(GuiSession session) : base(session)
        {
        }

        public void AssignTaskToTechnition()
        {
            PressButton(Resource);
            PressButton(Order);
            PressButton(Assignment);
            PressButton(Resourcedpd);
            SetCheckbox(Resourcename, true);
            PressButton(ContinueButton);


        }

        public void BlockAndUnblockTimeForATechnician()
        {
            PressButton(TimeAllocation);
            PressButton(Resourcedpd);
            SetCheckbox(Resourcename, true);
            PressButton(ContinueButton);
            TextFieldType(Description, "Test");
            SelectDropdownOption(Type, "TRAINING");
            //TODO Replace date with todays date
            TextFieldType(StartDate, GetSelectedDate("Today"));
            TextFieldType(StartTime, "1200");
            SendVKey(00);
            TextFieldType(EndDate, GetSelectedDate("Today"));
            TextFieldType(EndTime, "1210");
            SendVKey(00);
            PressButton(Create);
            //validate no locator
            PressButton(Deletebtn);
        }
    }
}
