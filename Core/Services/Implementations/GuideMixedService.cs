using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Base;
using Core.DTOs.Guia;
using Core.DTOs.Guias;
using Core.Models.Entities;
using Core.Seeder.Data;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;

namespace Core.Services.Implementations
{
    public class GuideMixedService : AtlasBaseServiceMixed<Guide, DtoGuiaRequest, DtoGuiaResponse>, IGuideMixedService
    {
        public GuideMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
        {
        }

        public override async Task <DtoGuiaResponse> GetDocs(string identifies, string? resourceName = null)
        {
            var mapped = _Mapper.Map<DtoGuiaResponse>( GuideData.Pdf );
        
            return mapped;
            
        }


        public override async Task<AtlasMixedResponse< DtoGuiaResponse >> GetById(int id)
        {
             var mapped = _Mapper.Map<DtoGuiaResponse>( GuideData.Pdf );
        
            return await Task.FromResult( 

                new AtlasMixedResponse<DtoGuiaResponse>()
                {
                    MainResource = mapped
                }
             );
            
        }


      

    }
}