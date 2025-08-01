using Core.Models.Entities.BaseEntity;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces.Base;
using InertiaCore;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
     public class AtlasBaseController<TBaseEntity> : AtlasBaseJsonController<TBaseEntity> where TBaseEntity : BaseEntity
    {
        private readonly string _resourceName;
        public AtlasBaseController(IBaseService<TBaseEntity> baseService) : base(baseService)
        {
            _resourceName = typeof(TBaseEntity).Name;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                _baseService.UoW.Begin();
                var items = await _baseService.GetAll();
                _baseService.UoW.Commit();

                return Inertia.Render($"{_resourceName}/pages/IndexPage", new { items });
            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            try
            {
                _baseService.UoW.Begin();
                var item = await _baseService.GetById(id);
                _baseService.UoW.Commit();

                return Inertia.Render($"{_resourceName}/pages/DetailsPage", new { item });

            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var items = new { };
                return await Task.FromResult(Inertia.Render($"{_resourceName}/pages/CreatePage", items));

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var item = await _baseService.GetById(id);
                if (item == null)
                    return BadRequest();

                return await Task.FromResult(Inertia.Render($"{_resourceName}/pages/EditPage", new { item }));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }





        [HttpPost]
        public async Task<IActionResult> Store([FromForm] TBaseEntity entityToCreate)
        {
            try
            {
                _baseService.UoW.Begin();

                var response = await _baseService.Create(entityToCreate);

                _baseService.UoW.Commit();

                return Inertia.Render($"{_resourceName}/pages/IndexPage", new { entityToCreate });

            }
            catch (Exception ex)
            {
                _baseService.UoW.RollBack();
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TBaseEntity entityToUpdate, int id)
        {
            try
            {
                _baseService.UoW.Begin();

                var response = await _baseService.Edit(entityToUpdate, id);

                _baseService.UoW.Commit();

                return Inertia.Render($"{_resourceName}/pages/IndexPage", new { entityToUpdate });

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
