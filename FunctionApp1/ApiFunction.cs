using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp1.Messages;
using System.Collections.Generic;
using FunctionApp1.HttpRequestImplementation;

namespace FunctionApp1
{
    public class ApiFunction
    {
        [FunctionName("ApiFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Queue("messagetomom")] IAsyncCollector<MessageToMom> letterCollector,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //TODO model HttpRequest from fields of MessageToMom
            //Map new model values (from HttpRequest) to MessageToMom below

            //Abstracted Implementation to a private Method.
            MessageToMom Message = GetParameterRequest(req);
            await letterCollector.AddAsync(Message);

            return (ActionResult)new OkObjectResult($"Hello, Johnny");
        }

        // Private method to handle Requests
        private MessageToMom GetParameterRequest(HttpRequest req)
        {
            IHttpRequestLogic httpRequestLogic;

            switch (req.Method)
            {
                //Handle Post Requests.
                case "POST":
                    httpRequestLogic = new PostImplementation();
                    break;

                //Handle Get Requests.
                case "GET":
                    httpRequestLogic = new GetImplementation();
                    break;

                //Return Default Data.
                default:
                    httpRequestLogic = new DefaultImplementation();
                    break;
            }

            return httpRequestLogic.Execute(req);
        }
    }
}
