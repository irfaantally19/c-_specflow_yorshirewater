using Core_Framework.SAP;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SAP.Pages.SAP_GUI
{
    public abstract class Abstract_SAP_S4_Page : AbstractSAPPage
    {
        protected Abstract_SAP_S4_Page(GuiSession session) : base(session)
        {
        }

        #region Defined generic elements
        /* Monday
         Generic Elements
        */
        public By PersonnelNumber { get; private set; } = By.Name("RP50G-PERNR", "GuiCTextField");
        public By SubType { get; private set; } = By.Name("RP50G-SUBTY", "GuiCTextField");
        public By InfoType { get; private set; } = By.Name("RP50G-CHOIC", "GuiCTextField");
        public By Shell { get; private set; } = By.Name("Shell", "GuiSplitterShell");
        public By PencilBtn { get; private set; } = By.Id("wnd[0]/tbar[1]/btn[6]");
        public By SaveBtn { get; private set; } = By.Id("wnd[0]/tbar[0]/btn[11]");
        public By CreateBtn { get; private set; } = By.Id("wnd[0]/tbar[1]/btn[5]");
        public By DelimitBtn { get; private set; } = By.Id("wnd[0]/tbar[1]/btn[13]");
        public By DisplayBtn { get; private set; } = By.Id("wnd[0]/tbar[1]/btn[7]");
        public By Window { get; private set; } = By.Id("wnd[0]");
        public By Statusbar { get; private set; } = By.Name("sbar", "GuiStatusbar");
        public By UserArea { get; private set; } = By.Name("usr", "GuiUserArea");
        public By TitleStatusbar { get; private set; } = By.Name("titl", "GuiTitlebar");
        public By ExecuteButton { get; private set; } = By.Id("wnd[0]/tbar[1]/btn[8]");
        public By PrinterButton { get; private set; } = By.Id("wnd[1]/tbar[0]/btn[86]");
        public By ContinueButton { get; private set; } = By.Id("wnd[1]/tbar[0]/btn[0]");
        public By ChooseButton { get; private set; } = By.Id("wnd[1]/tbar[0]/btn[2]");
        public By CancelButton { get; private set; } = By.Id("wnd[1]/tbar[0]/btn[12]");

        public By PeriodRadioBtns(string value) => By.Name("RP50G-TIMR" + value, "GuiRadioButton");

        #endregion
        public void SendVKey(int vKey)
        {
            GuiMainWindow window = (GuiMainWindow)FindOne(By.Id("wnd[0]"));
            window.SendVKey(vKey);
        }

        public void SetRadioBtn(By by)
        {
            GuiRadioButton radioBtn = (GuiRadioButton)FindOne(by);
            radioBtn.Select();
        }

        public void SetCheckbox(By by, bool check)
        {
            var checkbox = (GuiCheckBox)FindOne(by);
            checkbox.Selected = check;
        }

        //WJE20220816
        public void SelectComboBox(By by, string strValue)
        {
            var comboBox = (GuiComboBox)FindOne(by);
            comboBox.Value = strValue;
        }

        //Find GuiUsrArea label using the text content - WJE20220815
        public bool FindUsrAreaLabel(By by, string strValue)
        {
            bool Found = false;
            int i = 0;
            var usrObj = (GuiUserArea)FindOne(by);

            while (i < usrObj.Children.Length)
            {
                var label = (GuiLabel)FindOne(By.Id(usrObj.Children.Item(i).Id));

                //Console.WriteLine("'" + label.Text + "'");

                if ((label.Text).Trim() == strValue)
                {
                    Found = true;
                    i = usrObj.Children.Length;
                }
                i += 1;
            }
            return Found;
        }

        //If the table cells are GuiTextField then search for cell by value and select - WJE20220818
        public void TableCellSelect(By by, string strValue)
        {
            int i = 0;
            var tblObj = (GuiTableControl)FindOne(by);

            while (i < tblObj.Children.Length)
            {
                var cellObj = (GuiTextField)FindOne(By.Id(tblObj.Children.Item(i).Id));

                if ((cellObj.Text).Trim() == strValue)
                {
                    cellObj.SetFocus();
                    i = tblObj.Children.Length;
                }
                i += 1;
            }
        }

        //Select branch in tree structure - WJE20230328
        //nodeKey string e.g. "02"
        //strValue string e.g. "Column1", yes the column name not the value
        public void TableTreeDoubleClick(By by, string nodeKey, string strValue)
        {
            var shellObj = (GuiTree)FindOne(by);
            shellObj.DoubleClickItem(nodeKey, strValue);
            
        }

        //Select text field - WJE20220817
        public void TextFieldSelect(By by)
        {
            var txtField = (GuiTextField)FindOne(by);
            txtField.SetFocus();
        }


        //WJE20220817
        public void IfExistPressBtn(By by)
        {
            try
            {
                var btn = ((GuiButton)FindOne(by));
                btn.Press();
            }
            catch 
            {
                //Do nothing...
            }
        }

        //Scrape value from text box and return - WJE20220727
        public string ScrapeTxb(By by)
        {
            return ((GuiTextField)FindOne(by)).Text;
        }

        //Return the number of rows in a Grid View - WJE20220725
        public int GetGridViewRowCount(By by)
        {
            var element = (GuiGridView)FindOne(by);
            return element.RowCount;
        }

        //Double click on row and column - WJE20220725
        //Hint: use record and playback to get the column name
        public void DoubleClickGridViewCell(By by, int rowNum, string column)
        {
            var element = (GuiGridView)FindOne(by);
            element.DoubleClick(rowNum, column);
        }

        //Return the value in a cell of a GuiGridView object - WJE20220725
        //ByValue row as int
        //ByValue column as String 
        public String GetGridCellValue(By by, int row, String column)
        {
            var gridView = (GuiGridView)FindOne(by);
            return gridView.GetCellValue(row, column);

        }

        //Click on Grid View tool bar button - WJE20220727
        public void ClickGridViewToolbarButton(By by, string buttonId)
        {
            var element = (GuiGridView)FindOne(by);
            element.PressToolbarButton(buttonId);
        }

        //Double click on the current cell on the Grid View - WJE20220725
        public void DoubleClickGridViewCurrentCell(By by)
        {
            var element = (GuiGridView)FindOne(by);
            element.DoubleClickCurrentCell();
        }

        //Getting a list of all the button Id's (Names) - WJE20220725
        public string[] GetGridViewToolbarButtons(By by)
        {
            var element = (GuiGridView)FindOne(by);
            string[] nameBtn = new string[element.ToolbarButtonCount];
            for (int i = 0; i < element.ToolbarButtonCount; i++)
            {
                nameBtn[i] = element.GetToolbarButtonId(i);
            }
            return nameBtn;
        }

        //Get Gui Label text - WJE20220725
        public string GetGuiLabelText(By by)
        {
            return ((GuiLabel)FindOne(by)).Text;
        }

        //WJE20220927
        public void TexteditType(By by, string value)
        {
            var element = (GuiTextedit)FindOne(by);
            element.SetFocus();
            element.Text = value;
        }

        public void FocusSetText(By by, string value)
        {
            var element = (GuiTextField)FindOne(by);
            element.SetFocus();
            element.Text = value;
        }


        //PaddyTest
        public void SelectDropdownOption(By by, string keyNumber)
        {
            var combobox = (GuiComboBox)FindOne(by);
            string newKey = keyNumber;
            combobox.Key = newKey;
        }

        public void ComboTextType(By by, string strValue)
        {
            var comboBox = (GuiComboBox)FindOne(by);
            comboBox.Text = strValue;
        }
        //Select item from dropdownlist using KeyNumber - RM20220812
        public void SelectDropdownOptionFocusNotSet(By by, string keyNumber)
        {
            var combobox = (GuiComboBox)FindOne(by);
            string newKey = keyNumber;
            combobox.Key = newKey;
        }
        
        public string GetGuiStatusPaneText(By by)
        {
            return ((GuiStatusPane)FindOne(by)).Text;
        }


        //PaddyTest
        public string ScrapeTitle(By by)
        {
            return ((GuiTitlebar)FindOne(by)).Text;
        }

        //PaddyTest
        public string ScrapeStatus(By by)
        {
            return ((GuiStatusbar)FindOne(by)).Text;
        }

        //PaddyTest
        public string GetSelectedDate(string selectedDate)
        {
            DateTime dt1 = DateTime.Now;
            string dateRequested;
            bool FirstOfTheMonth = false;
            string currentDay;

            if (selectedDate == "Today")
            {

            }
            else if (selectedDate == "Tomorrow")
            {
                dt1 = dt1.AddDays(1);
            }
            else if (selectedDate == "Yesterday")
            {
                dt1 = dt1.AddDays(-1);
            }
            else if (selectedDate == "NextMonth")
            {
                dt1 = dt1.AddMonths(1);
            }
            else if (selectedDate == "LastMonth")
            {
                dt1 = dt1.AddMonths(-1);
            }
            else if (selectedDate == "StartOfThisMonth")
            {
                FirstOfTheMonth = true;
            }
            else if (selectedDate == "StartOfNextMonth")
            {
                dt1 = dt1.AddMonths(1);

                FirstOfTheMonth = true;
            }
            else if (selectedDate == "NextYear")
            {
                dt1 = dt1.AddYears(1);
            }
            else if (selectedDate == "LastYear")
            {
                dt1 = dt1.AddYears(-1);
            }

            if (FirstOfTheMonth == true)
            {
                currentDay = "01";
            }
            else
            {
                currentDay = dt1.ToString("dd");
            }
            var currentMonth = dt1.ToString("MM");
            var currentYear = dt1.Year;

            dateRequested = currentDay + "." + currentMonth + "." + currentYear;

            return dateRequested;
        }

        //PaddyTest      
        public string ConfirmFieldContents(By by, string fieldType, string expectedValue)
        {

            string actualValue = "";
            string actualName = "";

            if (fieldType == "GuiTextField")
            {
                actualValue = ((GuiTextField)FindOne(by)).Text;
                actualName = ((GuiTextField)FindOne(by)).Name;
            }
            else if (fieldType == "GuiComboBox")
            {
                actualValue = ((GuiComboBox)FindOne(by)).Key;
                actualName = ((GuiComboBox)FindOne(by)).Name;
            }
            else if (fieldType == "GuiTitlebar")
            {
                actualValue = ((GuiTitlebar)FindOne(by)).Text;
                actualName = ((GuiTitlebar)FindOne(by)).Name;
            }
            else if (fieldType == "GuiStatusbar")
            {
                actualValue = ((GuiStatusbar)FindOne(by)).Text;
                actualName = ((GuiStatusbar)FindOne(by)).Name;
            }

            if (actualValue == expectedValue)
            {
                Console.WriteLine(actualName + " - ACTUAL RESULT IS: '" + actualValue + "' AND EXPECTED RESULT IS: '" + expectedValue + "' ARE A MATCH");
            }
            else
            {
                TestFailed(actualName + " - ACTUAL RESULT IS: '" + actualValue + "' AND EXPECTED RESULT IS: '" + expectedValue + "' ARE NOT A MATCH !!!!!");
            }
            return actualValue;
        }

        //PaddyTest
        public void SelectGuiTableControlRow(By by, int rowNum)
        {
            var element = (GuiTableControl)FindOne(by);
            element.GetAbsoluteRow(rowNum).Selected = true;
        }

        //PaddyTest
        public void CompareGuiControlTableValue(By by, string expectedValue, int rowNum, int columnNum)
        {
            var element = (GuiTableControl)FindOne(by);

            var actualValue = element.GetCell(rowNum, columnNum).Text;
            actualValue = actualValue.Trim();
            if (expectedValue == actualValue)
            {
                Console.WriteLine("ACTUAL RESULT: '" + actualValue + "' AND EXPECTED RESULT: '" + expectedValue + "' ARE A MATCH");
            }
            else
            {
                TestFailed("ACTUAL RESULT: '" + actualValue + "' AND EXPECTED RESULT: '" + expectedValue + "' ARE NOT A MATCH !!!!!");
            }
        }

        //PaddyTest
        public void CompareGuiShellColumnValues(By by, string expectedValue, string columnName)
        {
            var element = (GuiGridView)FindOne(by);
            int rowCount = element.RowCount;
            int currentRow = 0; //FIRST RESULT IS ON ROW 0

            Console.WriteLine("The Total Number of results showing is: " + rowCount);

            while (currentRow < rowCount)
            {
                var actualValue = element.GetCellValue(currentRow, columnName);

                if (expectedValue == actualValue)
                {
                    Console.WriteLine("CURRENT VALUE '" + actualValue + "' IS EQUAL TO EXPECTED VALUE '" + expectedValue + "' FOR ROW NUMBER: " + currentRow);
                }
                else
                {
                    TestFailed("CURRENT VALUE '" + actualValue + "' IS NOT EQUAL TO EXPECTED VALUE '" + expectedValue + "' FOR ROW NUMBER: " + currentRow + " !!!!!");
                }
                currentRow++;
            }
        }        



        #region MondayIgwe
        /// <summary>
        /// Validate GuiControlTable Contains Value
        /// </summary>
        /// <param name="by"></param>
        /// <param name="containValue"></param>
        /// <param name="rowNum"></param>
        /// <param name="columnNum"></param>
        public void ValidateGuiControlTableContainsValue(By by, string containValue, int rowNum, int columnNum)
        {
            var element = (GuiTableControl)FindOne(by);
            var actualValue = element.GetCell(rowNum, columnNum).Text;
            Assert.IsTrue(actualValue.Contains(containValue));
        }

        /// Specify the locator element
        /// And Select using a key from a dropdown
        /// </summary>
        /// <param name="by"></param>
        /// <param name="key"></param>
        public void SelectGuiComboBoxDropdownOptionByKey(By by, string setkey)
        {
            var combobox = (GuiComboBox)FindOne(by);
            combobox.SetFocus();

            if (combobox.Key.Equals(setkey))
                combobox.Key = setkey;
            else
                combobox.Key = setkey;
        }

        /// <summary>
        /// Specify the locator element
        /// And Select using a value from a dropdown
        /// </summary>
        /// <param name="by"></param>
        /// <param name="Value"></param>
        public void SelectGuiComboBoxDropdownOptionByValue(By by, string setValue)
        {
            var combobox = (GuiComboBox)FindOne(by);
            combobox.SetFocus();

            if (combobox.Value.Equals(setValue))
                combobox.Value = setValue;
            else
                combobox.Value = setValue;
        }

        /// <summary>
        /// Double Click GuiGridView Row
        /// </summary>
        /// <param name="by"></param>
        /// <param name="VKey"></param>
        /// <param name="currentRow"></param>
        public void DoubleClickGuiShellRow(By by, int VKey, int currentRow)
        {
            var element = (GuiGridView)FindOne(by);
            var rowCount = element.RowCount;
            var columnCount = element.ColumnCount;

            if (rowCount > 0 || columnCount > 0)
            {
                SendVKey(VKey);
                element.DoubleClick(currentRow, element.CurrentCellColumn);
            }
           
        }

        /// <summary>
        /// Validate the current screen title
        /// </summary>
        /// <param name="by"></param>
        /// <param name="screenTitle"></param>
        public void ValidateScreenGuiTitlebar(By by, string screenTitle)
        {
            var screenTitleValue = ((GuiTitlebar)FindOne(by)).Text;
            Assert.That(screenTitleValue.Equals(screenTitle), $"Failed to validate screen title, Expected is: {screenTitle}, Actual is: {screenTitleValue} ");
        }

        /// <summary>
        /// Validate text is displayed in GuicTextField element
        /// </summary>
        /// <param name="by"></param>
        /// <param name="text"></param>
        public void ValidateGuiCTextFieldtDisplayed(By by, string text)
        {
            string value = ((GuiCTextField)FindOne(by)).Text;
            Assert.IsTrue((value.Equals(text)), $"Failed to validate that {text} is visible - "
               + " Expected: " + text + " Actual: " + value);
        }

        /// <summary>
        /// Validate text is displayed in GuicTextField element
        /// </summary>
        /// <param name="by"></param>
        /// <param name="text"></param>
        public void ValidateGuiTextDisplayed(By by, string text)
        {
            string value = ((GuiTextField)FindOne(by)).Text;
            Assert.That(value.Equals(text), "Personel Numbers Were Processed Successfully  - "
               + " Expected: " + text + " Actual: " + value);
        }


        /// <summary>
        /// Validating the status bar text message
        /// </summary>
        /// <param name="by"></param>
        /// <param name="statusbarMessage"></param>
        public void ValidateGuiStatusbarMessages(By by, string statusbarMessage)
        {
            string statusbarValue = ((GuiStatusbar)FindOne(by)).Text;
            statusbarValue = statusbarValue.Trim();
            statusbarValue = statusbarValue.Replace(".", "");

            switch (statusbarValue)
            {
                case "No change found":
                    statusbarMessage = "No change found";

                    Assert.That(statusbarValue.Equals(statusbarMessage), "Record was not created succesffully - "
                    + " Expected: " + statusbarMessage + " Actual: " + statusbarValue);
                    PressButton(SaveBtn);
                    break;
                case "Record created":
                    Assert.That(statusbarValue.Equals(statusbarMessage), "Record was not created succesffully - "
                     + " Expected: " + statusbarMessage + " Actual: " + statusbarValue);
                    break;
                case "A Priority Court Order type SCA1 is already in existence":
                    Assert.That(statusbarValue.Equals(statusbarMessage), "Record was not created succesffully - "
                     + " Expected: " + statusbarMessage + " Actual: " + statusbarValue);
                    break;
                case "Employee reference Number already exist for employee":
                    Assert.That(statusbarValue.Equals(statusbarMessage), "Record was not created succesffully - "
                      + " Expected: " + statusbarMessage + " Actual: " + statusbarValue);
                    break;
                case "CSL entry already exist":
                    Assert.That(statusbarValue.Equals(statusbarMessage), "Record was not created succesffully - "
                      + " Expected: " + statusbarMessage + " Actual: " + statusbarValue);
                    break;
                case "":
                    Assert.That(statusbarValue.Equals((statusbarMessage.Replace(statusbarMessage, ""))), "Status bar has no text message displayed - "
                      + " Expected: " + statusbarMessage + " Actual: " + statusbarValue);
                    break;
                default:
                    Console.WriteLine($"Failed to validate status bar message, Expected is: {statusbarMessage}, Actual is: {statusbarValue} ");
                    break;
            }

        }



        /// <summary>
        /// Determine the status bar warning message
        /// <param name="by"></param>
        /// </summary>
        public void GetGuiStatusbarWarningMessages(By by)
        {
            var statusbarValue = ((GuiStatusbar)FindOne(by)).Text;

            while (SaveBtn != null || statusbarValue.Length > 0)
            {
                if (statusbarValue.Contains("past"))
                {
                    PressButton(SaveBtn);
                    return;
                }
                else if (statusbarValue.Trim().Contains("This entry deletes a record"))
                {
                    PressButton(SaveBtn);
                    return;
                }
                else if (statusbarValue.Trim().Contains("This entry will delete"))
                {
                    PressButton(SaveBtn);
                    return;
                }
                else if (statusbarValue.Contains("Enter data for correction period for payroll area"))
                {
                    PressButton(SaveBtn);
                    if (statusbarValue.Contains("delimited at"))
                    {
                        PressButton(SaveBtn);
                        return;
                    }
                    return;
                }
                else if (statusbarValue.Contains("delimited at"))
                {
                    PressButton(SaveBtn);
                    return;
                }
                else if (statusbarValue.Contains("Record delimited"))
                {
                    return;
                }
                else if (statusbarValue.Contains("No record selected"))
                {
                    return;
                }
                return;
            }
        }

        public void SelectTab(By by)
        {
            var element = (GuiTab)FindOne(by);
            element.Select();
        }

        public bool IsButtonPresent(By by)
        {
            try
            {
                var button = (GuiButton)FindOne(by);
                return true;
            }
            //catch (Exception ex)
            catch
            {
                return false;
            }
        }

        public bool IsTextFieldPresent(By by)
        {
            try
            {
                var textField = (GuiTextField)FindOne(by);
                return true;
            }
            //catch (Exception ex)
            catch
            {
                return false;
            }
        }
    }
    #endregion
}
