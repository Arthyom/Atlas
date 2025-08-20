using System;
using Core.Models.Entities.Base;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base;

public class AtlasBaseJsonController<TBaseEntity> : Controller where TBaseEntity : BaseEntity
    {
        protected IBaseService<TBaseEntity> _baseService;


        public AtlasBaseJsonController(IBaseService<TBaseEntity> baseService)
        {
            _baseService = baseService;
        }


        // GET: CityHallBaseJsonController
        [HttpGet]
        [Route("[controller]/json/index")]
        public async Task<IActionResult> IndexAsJson()
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


        [HttpGet]
        [Route("[controller]/json/index/{id}")]
        public async Task<ActionResult> GetByAsJson(int Id)
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