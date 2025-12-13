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
    public class EnvioController : AtlasMixedFileBaseController<Envio, DtoApiRequestEnvio, DtoApiResponseEnvio>
    {
        // public PurchaseController(IShippingMixedService baseService) : base(baseService, "Purchase")
        public EnvioController(IShippingMixedService baseService) : base(baseService)
        {
        }
    }
}