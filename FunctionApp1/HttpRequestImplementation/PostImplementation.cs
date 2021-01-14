using FunctionApp1.Messages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FunctionApp1.HttpRequestImplementation
{
    public class PostImplementation : IHttpRequestLogic
    {
        public MessageToMom Execute(HttpRequest req)
        {
            var bodyStream = new StreamReader(req.Body);
            bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
            var bodyText = bodyStream.ReadToEnd();

            var convertedBodyText = JsonConvert.DeserializeObject<MessageToMom>(bodyText);
            return convertedBodyText;
        }
    }
}
