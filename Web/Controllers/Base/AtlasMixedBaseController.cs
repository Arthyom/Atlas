using Core.DTOs.Base;
using Core.Models.Entities.BaseEntity;
using Core.Services.Interfaces.Base;
using InertiaCore;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    public class AtlasMixedBaseController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> : AtlasMixedJsonBaseController<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse>
    where TBaseEntity : BaseEntity
    where TBaseDtoRequest : AtlasBaseDto
    where TBaseDtoResponse: AtlasBaseDto
    {


        public AtlasMixedBaseController(IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> baseService) : base(baseService)
        {
        }


        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                // _baseService.UoW.Begin();
                var atlasResponse = await _baseService.GetAll();
                // _baseService.UoW.Commit();

                return Inertia.Render($"{_resourceName}/pages/IndexPage",  atlasResponse );
            }
            catch (Exception ex)
            {
                // _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            try
            {
                _baseService.UoW.Begin();
                var atlasResponse = await _baseService.GetById(id);
                _baseService.UoW.Commit();

                return Inertia.Render($"{_resourceName}/pages/DetailsPage",  atlasResponse );

            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                var atlasResponse = await _baseService.Create();
                return await Task.FromResult(Inertia.Render($"{_resourceName}/pages/CreatePage", atlasResponse));

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit( [FromRoute] int id)
        {
            try
            {
                var atlasResponse = await _baseService.Edit(id);
                if (atlasResponse == null)
                    return BadRequest();

                return await Task.FromResult(Inertia.Render($"{_resourceName}/pages/CreatePage", atlasResponse));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("view/{id}")]
        public async Task<IActionResult> View( [FromRoute] int id)
        {
            try
            {
                var atlasResponse = await _baseService.GetById(id);
                if (atlasResponse == null)
                    return BadRequest();

                return await Task.FromResult(Inertia.Render($"{_resourceName}/pages/CreatePage", atlasResponse));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }





        [HttpPost("store")]
        public async Task<IActionResult> Store([FromForm] TBaseDtoRequest entityToCreate)
        {
            try
            {
                _baseService.UoW.Begin();

                var response = await _baseService.Store(entityToCreate);

                _baseService.UoW.Commit();
                
                return Inertia.Location("index");

                // return Inertia.Render($"{_resourceName}/pages/IndexPage", entityToCreate);
            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update([FromForm] TBaseDtoRequest entityToUpdate, [FromRoute]int id)
        {
            try
            {
                _baseService.UoW.Begin();

                var response = await _baseService.Update(entityToUpdate, id);

                _baseService.UoW.Commit();

                var responseUrl = Request.Path.ToString().Split("/");

                string url = $"/{responseUrl[1]}/{responseUrl[2]}/index";

                return Inertia.Location(url);
            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _baseService.UoW.Begin();

                var response = await _baseService.delete(id);

                _baseService.UoW.Commit();

                return Inertia.Render($"{_resourceName}/pages/IndexPage", new { ok = response });

            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }





        
    }
}
