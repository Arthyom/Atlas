using Atlas.Core.Entities;
using Core.DTOs;
using Core.DTOs.Venta;
using Core.Models.Entities;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class VentaController : AtlasMixedFileBaseController<Venta, DtoVentaRequest, DtoVentaResponse>
    {
        public VentaController(IVentaMixedService baseService) : base(baseService)
        {
        }
    }
}
