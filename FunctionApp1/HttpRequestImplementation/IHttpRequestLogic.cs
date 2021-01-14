using FunctionApp1.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1.HttpRequestImplementation
{
    public interface IHttpRequestLogic
    {
        MessageToMom Execute(HttpRequest req);
    }
}
