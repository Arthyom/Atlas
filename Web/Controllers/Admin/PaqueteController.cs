using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Paquete;
using Core.Models.Entities;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class PaqueteController : AtlasMixedFileBaseController<Paquete, DtoPaqueteRequest, DtoPaqueteResponse>
    {
        public PaqueteController(IPaqueteMixedService baseService, string? resourceName = null) : base(baseService, resourceName)
        {
        }
    }
}