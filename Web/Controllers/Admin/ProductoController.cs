using Atlas.Core.Entities;
using Core.DTOs;
using Core.Services.Implementations;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class ProductoController : AtlasMixedFileBaseController<Producto, DtoProductoRequst, DtoProductoResponse>
    {
        public ProductoController(IProductoMixedService baseService) : base(baseService)
        {
        }
    }
}
