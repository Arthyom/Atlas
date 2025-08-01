using InertiaCore;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public async Task<Response> Index()
        {
            return await Task.FromResult(Inertia.Render("admin/pages/IndexPage"));
        }
    }
}
