using System;
using Atlas.Core.Entities;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.MiddleWares;

public class AuthSharedMiddleWrare
{

    private readonly RequestDelegate _next;

    public AuthSharedMiddleWrare( RequestDelegate next )
    {
        _next = next;
    }


    public async Task Invoke( HttpContext httpContext) {

        Usuario u = new Usuario()
        {
          Cp = "38800"  
        };

        // httpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject( u) );

        // InertiaCore.Inertia.Share( "User", u );
        
        // if( u.Cp == "38000")
        // {
        //     await _next( httpContext);
        //     return;
        // }
        //     // httpContext.Response.Redirect("/auth/index");
            // return;
        //    await _next(httpContext.Response.Redirect(""))
    }

}
