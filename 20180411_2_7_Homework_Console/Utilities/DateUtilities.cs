using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180411_2_7_Homework_Console.Utilities
{
    class DateUtilities
    {
        public static DateTime GetLegalAgeDate(int intYears)
        {
            return DateTime.Now.AddYears(-1 * intYears);
        }

        public static DateTime ValidateInputBirthdate()
        {
            Console.Write("Enter your birthdate as mm/dd/yyyy: ");
            DateTime birthdate = DateTime.MaxValue;

            try
            {
                birthdate = DateTime.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("you entered an invalid birthdate");
            }

            return birthdate;
        }

        public static bool CheckAge(DateTime legalAge, DateTime inputBirthDate)
        {
            if (inputBirthDate.CompareTo(legalAge) == 1)
            {
                Console.WriteLine("Sorry but you are not 21 - please select make a different drink selection");
                return false;
            }
            else
            {
                Console.WriteLine("Thank you for verifying your age.");
                return true;
            }
        }
    }
}
