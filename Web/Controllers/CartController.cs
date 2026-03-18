using Atlas.Core.Entities;
using Core.DTOs;
using Core.DTOs.Categoria;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class CartController : AtlasMixedFileBaseAnonimousController<Producto, DtoProductoRequst, DtoProductoResponse>
    {
        public CartController(IAtlasBaseServiceMixed<Producto, DtoProductoRequst, DtoProductoResponse> baseService) : base(baseService, "Cart")
        {
        }
    }
}
