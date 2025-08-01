using System;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Base;
using Core.Models.Entities.BaseEntity;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Implementations.Base;

public class AtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> : IAtlasBaseServiceMixed<TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> 
where TBaseEntity : BaseEntity
where TBaseDtoRequest : AtlasBaseDto
where TBaseDtoResponse: AtlasBaseDto
{
    private readonly IUnitOfWork _UoW;

    protected readonly IBaseRepository<TBaseEntity> _BaseRepository;

    protected readonly IMapper _Mapper;


    public IUnitOfWork UoW => _UoW;
    public IBaseRepository<TBaseEntity> repo => _BaseRepository;



    public AtlasBaseServiceMixed(IUnitOfWork UoW, IMapper mapper)
    {
        _UoW = UoW;
        _BaseRepository = _UoW.GetRepo<TBaseEntity>();
        _Mapper = mapper;
    }



    public async Task<Imagen> GetImages(string identifier, string? resourceName = null)
    {
        var imageRepo = _UoW.GetRepo<Imagen>();

        return await imageRepo.DbSet.Where(x => x.Identificador == identifier).FirstOrDefaultAsync() ?? throw new Exception("not found");
    }


    public virtual Task<bool> delete(TBaseEntity entity)
    {
        throw new NotImplementedException();
    }
    public virtual Task<bool> delete(int id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TBaseEntity> Edit(TBaseEntity entity, int id)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task<AtlasMixedResponse<TBaseDtoResponse>> Edit(int id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<AtlasMixedResponse<TBaseDtoResponse>> Update(TBaseDtoRequest dto, int id)
    {
         var respo = new AtlasMixedResponse<TBaseDtoResponse>();
        // respo.MainResourceCollection =  new List< DtoProductoResponse >().tolis ///await _BaseRepository.DbSet.ToListAsync();
        
        return await Task.FromResult( respo );
    }




    // public virtual async Task<AtlasMixedResponse<TBaseEntity>> GetAll()
    // {
    //     var respo = new AtlasMixedResponse<TBaseEntity>();
    //     respo.MainResourceCollection = await _BaseRepository.DbSet.ToListAsync();

    //     return respo;
    // }



    public virtual async Task<AtlasMixedResponse<TBaseDtoResponse>> GetById(int id)
    {
        var respo = new AtlasMixedResponse<TBaseDtoResponse>();

        // respo.MainResource = await _BaseRepository.DbSet.FirstOrDefaultAsync(x => x.Id == id);

        return await Task.FromResult(respo);
    }

    public virtual Task<AtlasMixedResponse<TBaseEntity>> Create()
    {
        throw new NotImplementedException();
    }

    public virtual Task<TBaseEntity> Store(TBaseEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<AtlasMixedResponse<TBaseDtoRequest>> Store(TBaseDtoRequest dto)
    {
        throw new NotImplementedException();
    }

    public Task<AtlasMixedResponse<TBaseDtoResponse>> GetAllMaped()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<AtlasMixedResponse<TBaseDtoResponse>> GetAll()
    {
         var respo = new AtlasMixedResponse<TBaseDtoResponse>();
        // respo.MainResourceCollection =  new List< DtoProductoResponse >().tolis ///await _BaseRepository.DbSet.ToListAsync();
        
        return await Task.FromResult( respo );
    }
}
