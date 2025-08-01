using Atlas.Core.Entities;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class CategoriaController : AtlasBaseController<Categoria>
    {
        public CategoriaController(IBaseService<Categoria> baseService) : base(baseService)
        {
        }
    }
}
