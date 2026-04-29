using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.DTOs;
using Core.DTOs.Base;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Implementations
{
    public class ProductoAnnMixedService : AtlasBaseServiceMixed<Producto, DtoProductoRequst, DtoProductoResponse>, IProductoAnnMixedService
    {
        public ProductoAnnMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
        {
        }


        public override async Task<AtlasMixedResponse<DtoProductoResponse>> GetAll()
        {
            AtlasMixedResponse<DtoProductoResponse> response = new AtlasMixedResponse<DtoProductoResponse>();

            var items = await _BaseRepository
                                    .DbSet
                                    .ProjectTo<DtoProductoResponse>(_Mapper.ConfigurationProvider)
                                    .ToListAsync();

       

            response.MainResourceCollection = items;

            return response;
        }


    }
}