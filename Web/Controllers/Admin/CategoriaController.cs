using Atlas.Core.Entities;
using Core.DTOs;
using Core.DTOs.Categoria;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class CategoriaController : AtlasMixedFileBaseController<Categoria, DtoCategoriaRequest, DtoCategoriaResponse>
    {
        public CategoriaController(ICategoriaMixedService baseService) : base(baseService)
        {
        }
    }
}
