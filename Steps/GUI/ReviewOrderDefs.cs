using Newtonsoft.Json;
using SAP.Pages.Models;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SAP.Steps.GUI
{
    [Binding]
    public class ReviewOrderDefs : StepDefinition
    {
        ReviewOrderListInfo info { get; set; }

        public ReviewOrderDefs(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When(@"The user reviews an order list ""(.*)""")]
        public void UserCreatesNewGeneralTaskList(string orderType)
        {
            SAP.ReviewOrderListPage.ReviewOrderList(_scenarioContext.Get<string>("OrderNumber"), orderType);
        }


        [Then(@"The user validates the order list")]
        public void ValidatesNewGeneralTaskList()
        {
            SAP.ReviewOrderListPage.ValidateOrderList(info);
        }


        [Given(@"The order list test data is set for a '(.*)'")]
        public void GivenTheTestDataIsSetForA(string jsonFileName)
        {
            var file = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\Data\ReviewOrderList\" + jsonFileName + ".json");
            info = JsonConvert.DeserializeObject<ReviewOrderListInfo>(File.ReadAllText(file));
        }

    }
}
