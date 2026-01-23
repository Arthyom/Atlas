using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Guia;
using Core.DTOs.Guias;
using Core.Models.Entities;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class GuideController : AtlasMixedFileBaseController<Guide, DtoGuiaRequest, DtoGuiaResponse>
    {
        public GuideController(IGuideMixedService baseService, string? resourceName = null) : base(baseService, resourceName)
        {
        }
    }
}