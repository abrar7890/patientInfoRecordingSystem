using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ABClassLibrary
{
    public static class ABValidations
    {
        /// <summary>
        /// capitalize the first letter of string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ABCapitalize(string value)
        {
            //check for null value
            if(value == null)
            {
                return string.Empty;
            }
            //if not null
            else
            {
                //shift to lower case
                value = value.ToLower().Trim();

                string[] valueSplit = value.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string newString = string.Empty;

                for(int i = 0;i < valueSplit.Length; i++)
                {
                    string s = valueSplit[i];
                    s = s.First().ToString().ToUpper() + s.Substring(1);
                    newString += s + " ";
                }
                return newString;
            }
        }

        /// <summary>
        /// extract only digits from string
        /// </summary>
        /// <param name="value">input string</param>
        /// <returns></returns>
        public static string ABExtractDigits(string value)
        {
            string digitsString = Regex.Replace(value, @"\D", "");
            return digitsString;
        }

        /// <summary>
        /// validates postal code
        /// if valid return true, otherwise false
        /// </summary>
        /// <param name="value">postal code</param>
        /// <returns>boolean true/false</returns>
        public static Boolean ABPostalCodeValidation(string value)
        {
            Regex pattern = new Regex(@"^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]\d[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxyz] ?\d[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxyz]\d$", RegexOptions.IgnoreCase);
            if (value == null || value.ToString() == "" || pattern.IsMatch(value))
            {
                return true;
            }
            else if(value.Trim() == " ")
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// format the postal code 
        /// </summary>
        /// <param name="value">postal code</param>
        /// <returns>new formatted postal code</returns>
        public static string ABPostalCodeFormat(string value)
        {
            string formattedPostalCode = string.Empty;

            if(value != null && value != "")
            {
                if (!value.Contains(" "))
                {
                    formattedPostalCode = value;
                    formattedPostalCode = formattedPostalCode.Insert(3, " ");
                    formattedPostalCode = formattedPostalCode.ToUpper();
                    return formattedPostalCode;
                }
                else
                {
                    value = value.ToUpper();
                    return value;
                }
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Shift ohip to upper case and Validate to "1234-123-123-XX" pattern 
        /// </summary>
        /// <param name="value">ohip</param>
        /// <returns></returns>
        public static bool ABOhipValidation(string value)
        {
            value = value.Trim().ToUpper();

            Regex formattedOhip = new Regex(
              @"^\d{4}-\d{3}-\d{3}-[A-Za-z]{2}$",
              RegexOptions.IgnoreCase);

            //check if formatted ohip is equal to what user came in;
            if (formattedOhip.IsMatch(value))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// validate the zipCode
        /// </summary>
        /// <param name="value">reference string</param>
        /// <returns></returns>
        public static Boolean ABZipCodeValidation(ref string value)
        {
            if(value == null || value == string.Empty)
            {
                value = "";
                return true;
            }

            string newString = "";
            newString = ABExtractDigits(value);

            if (newString.Length == 5)
            {
                return true;
            }
            else if (newString.Length == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
