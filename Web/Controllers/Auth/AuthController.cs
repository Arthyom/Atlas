using Azure;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Auth
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: AuthController


          public async Task<InertiaCore.Response>  Index()
        {
            return await Task.FromResult( Inertia.Render("auth/pages/IndexPage"));
        }


    }
}
