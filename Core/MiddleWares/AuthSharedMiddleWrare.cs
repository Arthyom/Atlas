using System;
using Microsoft.AspNetCore.Http;

namespace Core.MiddleWares;

public class AuthSharedMiddleWrare
{

    private readonly RequestDelegate _next;

    public AuthSharedMiddleWrare( RequestDelegate next )
    {
        _next = next;
    }


    public async Task Invoke( HttpContext httpContext) {
        await _next( httpContext);
    }

}
