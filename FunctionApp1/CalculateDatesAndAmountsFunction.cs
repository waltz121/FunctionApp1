using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionApp1.Messages;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class CalculateDatesAndAmountsFunction
    {
        [FunctionName("CalculateDatesAndAmountsFunction")]
        public async Task Run([QueueTrigger("messagetomom", Connection = "")]MessageToMom myQueueItem, 
            [Queue("outputletter")] IAsyncCollector<FormLetter> letterCollector,
            ILogger log)
        {
            log.LogInformation($"{myQueueItem.Greeting} {myQueueItem.HowMuch} {myQueueItem.HowSoon}");
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            FormLetter formLetter = new FormLetter();

            //TODO parse flattery list into comma separated string
            formLetter.parseFlatteryList(myQueueItem.Flattery);

            //TODO populate Header with salutation comma separated string and "Mother"
            formLetter.populateHeader();

            //TODO calculate likelihood of receiving loan based on this decision tree
            // 100 percent likelihood (initial value) minus the probability expressed from the quotient of howmuch and the total maximum amount ($10000)
            formLetter.calculateLikelihood(myQueueItem.HowMuch);

            //TODO calculate approximate actual date of loan receipt based on this decision tree
            // funds will be made available 10 business days after day of submission
            // business days are weekdays, there are no holidays that are applicable
            formLetter.calculateExpectedDate(myQueueItem.HowSoon);

            //TODO use new values to populate letter values per the following:
            //Body:"Really need help: I need $5523.23 by December 12,2020"
            //ExpectedDate = calculated date
            //RequestedDate = howsoon
            //Heading=Greeting
            //Likelihood = calculated likelihood
            
            formLetter.Body = "Really need help: I need $5523.23 by December 12,2020";
            formLetter.RequestedDate = myQueueItem.HowSoon.Value;
            await letterCollector.AddAsync(formLetter);
        }
    }


    
}
