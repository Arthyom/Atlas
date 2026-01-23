using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using Core.DTOs;
using Core.DTOs.Envio;
using Core.Models.Entities;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class EnvioController : AtlasMixedFileBaseController<Envio, DtoApiEnPeEnvioRequest, DtoApiEnPeEnvioResponse>
    {
        private readonly IEnvioMixedService _envioService;
        // public PurchaseController(IEnvioMixedService baseService) : base(baseService, "Purchase")
        public EnvioController(IEnvioMixedService baseService) : base(baseService)
        {
            _envioService = baseService;
        }


        // [HttpPost("file/{identifier}")]
        [HttpGet("GetShippingGuide/{identifier}")]
        public async Task<IActionResult> GetShippingGuide(string identifier)
        {
            try
            {
                var list = await _envioService.GetShippingGuide(identifier);
                return File(list.Info, "application/pdf");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // [HttpGet("file/{identifier}")]
        [HttpGet("GetShippingProviders")]
        public async Task<IActionResult> GetShippingProviders(string identifier)
        {
            try
            {
                var list = await _envioService.GetShippingProviders();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }



    }
}