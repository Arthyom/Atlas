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
        private readonly IProductoMixedService _baseServiceExtend;
        public ProductoController(IProductoMixedService baseService) : base(baseService)
        {
            _baseServiceExtend = baseService;
        }


        [HttpPost("BarCode")]
        public async Task<IActionResult> BarCode([FromBody] DtoProductoBarCodeRequest codes)
        {
            try
            {
                var list = await _baseServiceExtend.GetCodes(codes);
                return File(list, "application/pdf");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
