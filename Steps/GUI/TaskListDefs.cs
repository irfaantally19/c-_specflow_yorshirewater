using Newtonsoft.Json;
using SAP.Pages.Models;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SAP.Steps.GUI
{
    [Binding]
    public class TaskListDefs : StepDefinition
    {
        TaskListInfo info { get; set; }

        public TaskListDefs(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When(@"The user adds a general task list on group '(.*)' using strategy '(.*)'")]
        public void UserCreatesNewGeneralTaskList(string group, string strategy)
        {
            info.MaintenanceStrategy = strategy;
            info.TaskListGroup = group;
            info.TaskListHeader = strategy + " " + info.TaskListHeader;
            info.OperationDescirption = strategy + " " + info.OperationDescirption;
            SAP.TaskListPage.CreateGeneralTaskList(info);
        }

        [When(@"The user adds a general operation on group '(.*)' using strategy '(.*)'")]
        public void UserAddsGeneralOperation(string group, string strategy)
        {
            info.MaintenanceStrategy = strategy;
            info.TaskListGroup = group;
            info.TaskListHeader = strategy + " " + info.TaskListHeader;
            SAP.TaskListPage.AddGeneralOperation(info);
        }

        [Then(@"The user validates the general task list")]
        public void ValidatesNewGeneralTaskList()
        {
            SAP.TaskListPage.ValidateGeneralTaskList(info);
        }


        [Given(@"The test data is set for a '(.*)'")]
        public void GivenTheTestDataIsSetForA(string jsonFileName)
        {
            var file = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\Data\TaskList\" + jsonFileName + ".json");
            info = JsonConvert.DeserializeObject<TaskListInfo>(File.ReadAllText(file));
        }

    }
}
