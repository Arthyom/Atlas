using Azure;
using Core.DTOs.Auth;
using Core.DTOs.Usuario;
using Core.Services.Implementations;
using Core.Services.Interfaces;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Auth
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: AuthController

        private readonly IUsuarioMixedService  _service; 

        public AuthController(IUsuarioMixedService service)
        {
            _service = service;
        }

          public async Task<InertiaCore.Response>  Index()
        {
            return await Task.FromResult( Inertia.Render("auth/pages/IndexPage"));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoUsuarioRequest login)
        {
            try
            {    
                var s = await _service.Apply(login);

                if(s.MainResource != null)
                {
                        // return Redirect("/admin/producto/index");
                       //return RedirectToAction("index", "/admin/producto");
                                            //   return Inertia.Render("auth/pages/IndexPage");

                    //    return Inertia.Render("auth/pages/IndexPage");

                    return Ok();
                }

                else
                    return Problem();
                    // return Inertia.Render("auth/pages/IndexPage",null);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }


         [HttpGet()]
         [Route("auth/signout")]
        public  async Task<IActionResult> AtlasSignOut()
        {
            try
            {    
                var s = await _service.SignOut();
                // Inertia.Location("/auth/index");
                return  RedirectToAction("index");  //  Inertia.Render("admin/pages/IndexPage", s);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }


    }
}
