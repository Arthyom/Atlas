using System;
using Atlas.Core.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.DTOs;
using Core.DTOs.Base;
using Core.DTOs.Categoria;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Implementations;

public class CategoriaMixedService : AtlasBaseServiceMixed<Categoria, DtoCategoriaRequest, DtoCategoriaResponse>, ICategoriaMixedService
{
    public CategoriaMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
    {
    }

     public override async Task<AtlasMixedResponse<DtoCategoriaResponse>> GetAll()
    {
         var respo = new AtlasMixedResponse<DtoCategoriaResponse>();

        var mainCollection = await UoW.GetRepo<Categoria>()
            .DbSet
            .ProjectTo<DtoCategoriaResponse>( _Mapper.ConfigurationProvider)
            .ToListAsync();


        // respo.MainResourceCollection =  new List< DtoProductoResponse >().tolis ///await _BaseRepository.DbSet.ToListAsync();
        respo.MainResourceCollection = mainCollection;


        return await Task.FromResult(respo);
    }
}
