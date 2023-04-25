using Core_Framework.SAP;
using sapfewse;

namespace SAP.Pages.SAP_GUI
{
    public class DisplayAGOperationalPage : Abstract_SAP_S4_Page
    {

        private By OrderNumber = By.Name("CAUFVD-AUFNR", "GuiTextField");

        public DisplayAGOperationalPage(GuiSession session) : base(session)
        {
        }

        public string ExtractOrderNumber()
        {
            return OrderNumber.ToString();
        }
    }
}
