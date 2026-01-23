using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Base;
using Core.DTOs.Envio;
using Core.DTOs.Orden;
using Core.Models.Entities;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces
{
    public interface IEnvioMixedService : IAtlasBaseServiceMixed<Envio, DtoApiEnPeEnvioRequest , DtoApiEnPeEnvioResponse>
    {
        
        public Task<AtlasMixedResponse<DtoApiEnPeShippingProviderResponse>> GetShippingProviders();

        public Task<Guide> GetShippingGuide(string identifier);


    }
}