using Core.DTOs.Paquete;
using Core.Models.Entities;
using Core.Services.Interfaces.Base;
using InertiaCore;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class AdminController : AtlasMixedFileBaseController<Paquete, DtoPaqueteRequest, DtoPaqueteResponse>
    {
        public AdminController(IAtlasBaseServiceMixed<Paquete, DtoPaqueteRequest, DtoPaqueteResponse> baseService, string? resourceName = null) : base(baseService, resourceName)
        {
        }
    }
}
