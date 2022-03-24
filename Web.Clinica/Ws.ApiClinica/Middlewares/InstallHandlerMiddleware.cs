using Microsoft.AspNetCore.Builder;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws.ApiClinica.Middlewares.ErrorMiddlewares;

namespace SistemaSanFelipe.Services.Middlewares  
{
    public static class InstallHandlerMiddleware
    {
        public static IApplicationBuilder UseHandlerUsers(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
