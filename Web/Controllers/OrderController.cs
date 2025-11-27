using Core.DTOs;
using Core.DTOs.Api.Response;
using Core.Models.Entities;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using InertiaCore;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class OrderController : AtlasMixedBaseController<Order, DtoOrder, DtoOrderResponse>
    {
        public OrderController(IOrderService baseService, string? resourceName = null) : base(baseService, resourceName)
        {
        }


        [HttpPost("json/save", Order = -1)]
        public override async Task<IActionResult> Save([FromBody] DtoOrder entityToCreate)
        {
            try
            {
                _baseService.UoW.Begin();

                var response = await _baseService.Apply(entityToCreate);

                _baseService.UoW.Commit();
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }
    }
}
