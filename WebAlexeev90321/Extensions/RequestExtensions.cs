using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAlexeev90321.Extensions
{
    public static class RequestExtansions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request.Headers["x-requested-with"].Equals("XMLHttpRequest");
        }
    }
}
