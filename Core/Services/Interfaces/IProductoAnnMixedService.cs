using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using Core.DTOs;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces
{
    public interface IProductoAnnMixedService :IAtlasBaseServiceMixed<Producto, DtoProductoRequst, DtoProductoResponse>
    {
        
    }
}