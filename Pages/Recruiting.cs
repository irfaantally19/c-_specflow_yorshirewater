using OpenQA.Selenium;
using SAP.Pages.SAP_Web;
using System;


namespace SAP.Pages
{
    public class Recruiting : AbstractSAPWebPage
    {

        private By SelectRequisition = By.XPath("//*[contains(text(),'Operational CCTV Technician')]");
        private By JobStartDate = By.PartialLinkText("Job Start Date Required");
        private By OnboardingAdministratorField = By.Id("tor__fsecondRecruiterName_op_find_user");
        private By OfferAdvisorField = By.XPath("//*[@class= 'search-box globalRoundedCornersXSmall']");

        DateTime dateToday = DateTime.Now;
        DateTime dateNextMonth = DateTime.Now.AddMonths(+1);



        public Recruiting(IWebDriver dr) : base(dr)
        {

        }

        public override string _uri => throw new NotImplementedException();

        public override bool WaitforDisplayed()
        {
            throw new NotImplementedException();
        }
    }
}
