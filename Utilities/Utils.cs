using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SAP.Utilities
{
    public class Utils
    {
        public Utils() : base()
        {
        }

        //Find the start date of the current month - WJE20220815
        public static DateTime StartOfCurrentMonth()
        {
            DateTime today = DateTime.Now;
            DateTime StartDate = new DateTime(today.Year, today.Month, 1);
            return StartDate;
        }

        //Find the start date of the current month - WJE20220815
        public static DateTime MiddleOfCurrentMonth()
        {
            DateTime today = DateTime.Now;
            DateTime StartDate = new DateTime(today.Year, today.Month, 1);
            DateTime MiddleDate = StartDate.AddDays(15);

            if (MiddleDate.DayOfWeek == DayOfWeek.Sunday || MiddleDate.DayOfWeek == DayOfWeek.Saturday)
            {
                MiddleDate = StartDate.AddDays(13);
            }

            return MiddleDate;
        }

        //Find the start date of the current month - WJE20220815
        public static string BirthDate(int years)
        {
            DateTime DateOfBirth = DateTime.Now.AddYears(-years);
            return DateOfBirth.ToString("dd.MM.yyyy");
        }

        //Convert a numerical string value contain a decimal comma to a two decimal double value - WJE20220803
        public static double ConvertToDouble2Decimal(string strValue)
        {
            double dblValue;

            //Remove all nasty characters.
            strValue = strValue.Trim();                      //Remove all spaces from the string
            strValue = strValue.Replace("-", "");			 //Remove dashes
            strValue = strValue.Replace(".", "");            //Remove full stops
            strValue = strValue.Replace(",", ".");           //Replace decimal comma with decimal point
                                                             //Convert to decimal
            dblValue = double.Parse(strValue, System.Globalization.NumberStyles.AllowDecimalPoint);
            return Math.Round(dblValue, 2);           //Round to decimals
        }

        //Convert a numerical string value containing a decimal comma to a double value - WJE20220803
        public static double ConvertToDouble(string strValue)
        {
            double dblValue;

            //Remove all nasty characters.
            strValue = strValue.Trim();                      //Remove all spaces from the string
            strValue = strValue.Replace("-", "");			 //Remove dashes
            strValue = strValue.Replace(".", "");            //Remove full stops
            strValue = strValue.Replace(",", ".");           //Replace decimal comma with decimal point
                                                             //Convert to decimal
            dblValue = double.Parse(strValue, System.Globalization.NumberStyles.AllowDecimalPoint);
            return dblValue;
        }

        //Convert a integer string value to integer - WJE20220803
        public static int ConvertToInt(string strValue)
        {
            int intValue;

            //Remove all nasty characters.
            strValue = strValue.Trim();                      //Remove all spaces from the string
            strValue = strValue.Replace("-", "");			 //Remove dashes
            strValue = strValue.Replace(".", "");            //Remove full stops

            intValue = int.Parse(strValue, System.Globalization.NumberStyles.Integer);
            return intValue;
        }


        //Convert a numerical string value containing a decimal point to a double value - WJE20220829
        public static double StringDecimalPointToDouble(string strValue)
        {
            double dblValue;

            //Remove all nasty characters.
            strValue = strValue.Trim();                      //Remove all spaces from the string
            strValue = strValue.Replace("-", "");			 //Remove dashes

            dblValue = double.Parse(strValue, System.Globalization.NumberStyles.AllowDecimalPoint);
            return dblValue;

        }
    }
}
