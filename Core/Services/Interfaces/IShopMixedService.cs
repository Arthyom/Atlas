using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using Core.DTOs;
using Core.DTOs.Base;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces
{
    public interface IShopMixedService : IAtlasBaseServiceMixed<Producto, DtoProductoRequst, DtoProductoResponse>
    {
            

        public async Task<AtlasMixedResponse<DtoProductoResponse>> GetCart() {

            return await Task.FromResult( new AtlasMixedResponse<DtoProductoResponse>());

        }
    }
}