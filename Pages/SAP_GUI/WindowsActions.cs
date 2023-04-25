using Core_Framework.Desktop.CodedUI;
using Interop.UIAutomationClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Pages.SAP_GUI
{
    public class WindowsActions : AbstractPage
    {
        private UIBy OkBtn = UIBy.Name("OK");
        private UIBy SaveField = UIBy.AutomationID("1001");
        private UIBy SaveBtn = UIBy.AutomationID("1");
        public WindowsActions(CUIAutomation automationClass) : base(automationClass)
        {
        }

        public override IUIAutomationElement scopedElement { get; set; }
        private UIBy Scope { get; set; }

        public override UIBy PageScopeCondition()
        {
            return Scope;
        }

        public void AcceptSAPLogion()
        {
            Scope = UIBy.Name("SAP Login");
            Click(OkBtn);
        }

        public string SavePDF(string filepath)
        {
            Directory.CreateDirectory(filepath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            Scope = UIBy.Name("Save As");
            SendKeys(SaveField, filepath);
            Click(SaveBtn);
            return filepath;
        }


        public override bool WaitForDisplayed()
        {
            throw new NotImplementedException();
        }
    }
}
