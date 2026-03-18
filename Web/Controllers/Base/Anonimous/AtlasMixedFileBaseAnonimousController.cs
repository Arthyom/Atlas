using Core.DTOs.Base;
using Core.Models.Entities.Base;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    public class AtlasMixedFileBaseAnonimousController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> :
    AtlasMixedBaseAnonimousController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse>
    where TBaseEntity : BaseEntity
    where TBaseDtoRequest : AtlasBaseDto
    where TBaseDtoResponse : AtlasBaseDto
    {
        public AtlasMixedFileBaseAnonimousController(IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> baseService, string? resourceName = null) : base(baseService, resourceName)
        {
        }


        [HttpGet("file/{identifier}")]
        public async Task<IActionResult> Get(string identifier)
        {
            try
            {
                var list = await _baseService.GetImages(identifier, _resourceName);
                return File(list.Info, "image/jpeg");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
