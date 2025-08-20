using System;
using Core.DTOs.Base;
using Core.Models.Entities.Base;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base;

[Route("{approachType?}/{controller}")]
public class AtlasMixedJsonBaseController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> : Controller
where TBaseEntity : BaseEntity
where TBaseDtoRequest : AtlasBaseDto
where TBaseDtoResponse : AtlasBaseDto
{
    protected readonly string _resourceName;

    protected IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> _baseService;



    public AtlasMixedJsonBaseController(IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> baseService)
    {
        _baseService = baseService;
        _resourceName = typeof(TBaseEntity).Name;
    }


    // GET: CityHallBaseJsonController
    [HttpGet("json")]
    // [Route("[controller]/json/index")]
    public async Task<IActionResult> List()
    {
        try
        {
            var list = await _baseService.GetAll();
            return Ok(list);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }


    [HttpGet("json/{id}")]
    // [Route("/admin/[controller]/json/{id}")]
    public async Task<ActionResult> By([FromRoute] int Id)
    {
        try
        {
            var item = await _baseService.GetById(Id);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }



}

