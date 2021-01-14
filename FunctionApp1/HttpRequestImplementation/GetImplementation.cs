using FunctionApp1.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1.HttpRequestImplementation
{
    public class GetImplementation : IHttpRequestLogic
    {
        public MessageToMom Execute(HttpRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
