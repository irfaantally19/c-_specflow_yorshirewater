using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SAP.Steps.WEB
{
    public class GeneralWebSteps : StepDefinition
    {
        public GeneralWebSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            GetDriver();
            SAPWeb = new(_driver);
        }
    }
}
