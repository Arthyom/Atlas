using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.Base;
using Core.Models.Entities.Base;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    public class AtlasMixedDocsBaseAnonimousController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> :
    AtlasMixedBaseAnonimousController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse>
    where TBaseEntity : BaseEntity
    where TBaseDtoRequest : AtlasBaseDto
    where TBaseDtoResponse : AtlasBaseDtoFile
    {
        public AtlasMixedDocsBaseAnonimousController(IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> baseService, string? resourceName = null) : base(baseService, resourceName)
        {
        }


        [HttpGet("pdf/{identifier}")]
        public async Task<IActionResult> pdf(string identifier)
        {
            try
            {
                var list = await _baseService.GetDocs(identifier, _resourceName);
                
                return File(  Encoding.ASCII.GetBytes(list.Info), "application/pdf");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}