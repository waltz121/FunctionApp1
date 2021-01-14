using FunctionApp1.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1.HttpRequestImplementation
{
    public class DefaultImplementation : IHttpRequestLogic
    {
        public MessageToMom Execute(HttpRequest req)
        {
            var message = new MessageToMom
            {
                Flattery = new List<string> { "amazing", "fabulous", "profitable" },
                Greeting = "So Good To Hear From You",
                HowMuch = 1222.22M,
                HowSoon = DateTime.UtcNow.AddDays(1),
                From = "yourbelovedson@gmail.com"
            };

            return message;
        }
    }
}
