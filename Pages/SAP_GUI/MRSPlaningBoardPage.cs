using Core_Framework.SAP;
using sapfewse;

namespace SAP.Pages.SAP_GUI
{
    public class MRSPlaningBoardPage : Abstract_SAP_S4_Page
    {
        //General elements
        private By ResourcePlanningNode = By.Id("wnd[0]/usr/ctxtSO_ORG-LOW");
        private By DemandID = By.Id("wnd[0]/usr/ctxtSO_ORDER-LOW");
        private By VariantSelection = By.Name("shell", "GuiShell");
        private By GetVariantbtn = By.Name("btn[17]", "GuiButton");


        public MRSPlaningBoardPage(GuiSession session) : base(session)
        {
        }

        /// <summary>
        /// Excutes with ordernumber
        /// </summary>
        /// <param name="planingNode"></param>
        /// <param name="orderNumber"></param>
        public void ExecuteMRSPlanning(string planingNode, string orderNumber)
        {
            WaitForSession();
            SendCommand("/n/MRSS/PLBOORGSRV");
            if (planingNode != null)
            {
                TextFieldType(ResourcePlanningNode, planingNode);
            }
            SelectVariant(orderNumber);
            TextFieldType(DemandID, orderNumber);
            SendVKey(8);
        }

        /// <summary>
        /// Selects the varian from the list
        /// </summary>
        /// <param name="orderNumber"></param>
        public void SelectVariant(string orderNumber)
        {
            TextFieldType(ResourcePlanningNode, "50028256");
            TextFieldType(DemandID, orderNumber);
        }
    }
}
