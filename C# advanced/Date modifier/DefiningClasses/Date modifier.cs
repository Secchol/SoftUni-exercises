using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Date_modifier
    {

        public static int CalculateDates(string firstDate, string secondDate)
        {
            string[] firstDateInfo = firstDate.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] secondDateInfo = secondDate.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int firstDateYear = int.Parse(firstDateInfo[0]);
            int secondDateYear = int.Parse(secondDateInfo[0]);
            int firstDateMonth = int.Parse(firstDateInfo[1]);
            int secondDateMonth = int.Parse(secondDateInfo[1]);
            int firstDateDay = int.Parse(firstDateInfo[2]);
            int secondDateDay = int.Parse(secondDateInfo[2]);


        }


    }
}
