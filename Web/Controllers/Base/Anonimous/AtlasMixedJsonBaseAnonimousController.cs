using System;
using Core.DTOs.Base;
using Core.Models.Entities.Base;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base;

[Route("{approachType?}/{controller}")]
public  class AtlasMixedJsonBaseAnonimousController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> : Controller
where TBaseEntity : BaseEntity
where TBaseDtoRequest : AtlasBaseDto
where TBaseDtoResponse : AtlasBaseDto
{
    protected  string _resourceName;

    protected IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> _baseService;



    public AtlasMixedJsonBaseAnonimousController(IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> baseService, string? resourceName = null)
    {
        _baseService = baseService;
        if( !string.IsNullOrEmpty(resourceName) )
            _resourceName = resourceName;
        else
        _resourceName = typeof(TBaseEntity).Name;
    }



      [HttpPost("json/save")]
        public virtual async Task<IActionResult> Save([FromBody] TBaseDtoRequest entityToCreate)
        {
            try
            {
                _baseService.UoW.Begin();

                var response = await _baseService.Apply(entityToCreate);

                _baseService.UoW.Commit();
                
                return Ok(response);
                // return Inertia.Render($"{_resourceName}/pages/IndexPage", entityToCreate);
            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
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


    [HttpPatch("json/{id}")]
    public async Task<IActionResult> Patch([FromBody] TBaseDtoRequest entityToUpdate, [FromRoute]int id)
    {
        try
        {
            _baseService.UoW.Begin();

            var response = await _baseService.Update(entityToUpdate, id);

            _baseService.UoW.Commit();

            return Ok(response);
        }
        catch (Exception ex)
        {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
        }
    }



}

