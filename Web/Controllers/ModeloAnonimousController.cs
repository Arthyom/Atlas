using Core.DTOs.Modelo;
using Core.Models.Entities;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class ModeloAnonimousController : AtlasMixedFileBaseAnonimousController<Modelo, DtoModeloRequest, DtoModeloResponse>
    {
        public ModeloAnonimousController(IModeloMixedService baseService) : base(baseService, "ModeloAnonimous")
        {
        }
    }
}
