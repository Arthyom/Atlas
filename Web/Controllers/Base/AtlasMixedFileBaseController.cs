using Core.DTOs.Base;
using Core.Models.Entities.BaseEntity;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    public class AtlasMixedFileBaseController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> :
    AtlasMixedBaseController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse>
    where TBaseEntity : BaseEntity
    where TBaseDtoRequest : AtlasBaseDto
    where TBaseDtoResponse : AtlasBaseDto
    {
        public AtlasMixedFileBaseController(IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> baseService) : base(baseService)
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
