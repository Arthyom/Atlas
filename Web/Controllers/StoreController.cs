using InertiaCore;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class StoreController : Controller
    {
        // GET: StoreController
        [HttpGet]
        public Task<Response> Index()
        {
            return Task
            .FromResult(Inertia.Render("store-front/pages/IndexPage"));
        }


        [HttpGet]
        public Task<Response> Product(int id)
        {
            return Task
            .FromResult(Inertia.Render("store-front/pages/ProductDetailsPage", new  { id }));
        }

    }
}
