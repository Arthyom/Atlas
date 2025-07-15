using InertiaCore;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        // GET: CartController
        public async Task<Response>  Index()
        {
            return await Task.FromResult(Inertia.Render("cart/pages/IndexPage"));
        }

    }
}
