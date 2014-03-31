using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCastleIntegration.Dependencies
{
    public class HelloWorldMessageSource: IMessageSource
    {
        public string GetMessage()
        {
            return "Hello World!";
        }
    }
}