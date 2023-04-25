using Core_Framework.SAP;
using NUnit.Framework;
using SAP.Pages.Models;
using sapfewse;

namespace SAP.Pages.SAP_GUI
{
    public class ReviewOrderListPage : Abstract_SAP_S4_Page
    {
        //General elements
        private By StatusBar = By.Id("wnd[0]/sbar");                //Buttom status bar
        private By TitleBar = By.Name("titl", "GuiTitlebar");       //Title bar
        private By Order = By.Name("S_AUFNR-LOW", "GuiCTextField");
        private By OrderType = By.Name("S_AUART-LOW", "GuiCTextField");
        private By OrderTypeReview = By.Name("CAUFVD-AUART", "GuiCTextField");
        private By OrderReview = By.Name("CAUFVD-AUFNR", "GuiTextField");
        private By CompletedCheckBox = By.Name("SP_MAB", "GuiCheckBox");
        private By StartDate = By.Name("S_DATUM-LOW", "GuiCTextField");
        private By EndDate = By.Name("S_DATUM-HIGH", "GuiCTextField");


        public ReviewOrderListPage(GuiSession session) : base(session)
        {
        }

        public void ReviewOrderList(string orderNumber, string orderType)
        {
            WaitForSession();
            SendCommand("/nIW49N");

            SetCheckbox(CompletedCheckBox, true);
            TextFieldType(Order, orderNumber);
            TextFieldType(OrderType, orderType);
            TextFieldType(StartDate, "");
            TextFieldType(EndDate, "");

            SendVKey(8);    //Execute F8
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

        public void ValidateOrderList(ReviewOrderListInfo info)
        {
            string orderReview = ScrapeTxb(OrderReview);
            string orderTypeReview = ScrapeTxb(OrderTypeReview);

            Assert.That(orderReview == info.Order, "Order number '" + info.Order + "' not found but order number '" + orderReview + "'.");
            Assert.That(orderTypeReview == info.OrderType, "Order type '" + info.OrderType + "' not found but order type '" + orderTypeReview + "'.");
            SendVKey(12); //Cancel to return to previous screen
            SendVKey(12); //Cancel to return to main screen
            //System.Threading.Thread.Sleep(5000); //DebugOFF
        }

    }
}
