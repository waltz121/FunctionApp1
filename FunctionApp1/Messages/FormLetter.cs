using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1.Messages
{
    public class FormLetter
    {
        public string Heading { get; set; }
        public double Likelihood { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Body { get; set; }

        private string flattery { get; set; }
        private const decimal MaximumAmount = 10000m;

        //Implement Business rules on Class for Decoupling and Easy Unit Testing
        public void parseFlatteryList(List<string> flatteryList)
        {
            flattery = string.Join(",",flatteryList);
        }

        public void calculateLikelihood(decimal howMuch)
        {
            //Implement Validation and Error handling
            if(howMuch > MaximumAmount)
            {
                throw new ArgumentException("howMuch is Greater than maximum Amount");
            }

            var probability =  100 * ((double)(howMuch / MaximumAmount));
            Likelihood = 100 - probability;
        }

        public void populateHeader()
        {
            Heading = flattery + " Mother";
        }

        public void calculateExpectedDate(DateTime? submissionDate)
        {
            if (submissionDate.HasValue)
            {
                ExpectedDate = AddBusinessDays(submissionDate.Value, 10);
            }
            else
            {
                //Implement Validation and Error handling
                throw new ArgumentException("Submission date is null");
            }
        }

        private DateTime AddBusinessDays(DateTime date, int days)
        {

            if(date < DateTime.Today)
            {
                //Implement Validation and Error handling
                throw new ArgumentException("Submission Date must be Greater than current date");
            }

            if (days == 0) return date;

            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(2);
                days -= 1;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
                days -= 1;
            }

            date = date.AddDays(days / 5 * 7);
            int extraDays = days % 5;

            if ((int)date.DayOfWeek + extraDays > 5)
            {
                extraDays += 2;
            }

            return date.AddDays(extraDays);
        }
    }
}
