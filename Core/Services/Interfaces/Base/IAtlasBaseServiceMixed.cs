using System;
using Atlas.Core.Entities;
using Core.DTOs.Base;
using Core.Models.Entities.BaseEntity;

namespace Core.Services.Interfaces.Base;

public interface IAtlasBaseServiceMixed <TBaseEntity, TBaseDtoRequest, TBaseDtoResponse> 
where TBaseEntity : BaseEntity
where TBaseDtoRequest : AtlasBaseDto
where TBaseDtoResponse : AtlasBaseDto

{


    public IUnitOfWork UoW { get; }
    public IBaseRepository<TBaseEntity> repo { get; }





    // public  Task<AtlasMixedResponse<TBaseEntity>> GetAll();
    public  Task<AtlasMixedResponse<TBaseDtoResponse>> GetAll();

    public Task <Imagen> GetImages(string identifies, string? resourceName = null);


    public Task<AtlasMixedResponse<TBaseDtoResponse>> GetById(int id);



    public Task<AtlasMixedResponse<TBaseEntity>> Create();

    public Task<TBaseEntity> Store(TBaseEntity entity);
    public Task<AtlasMixedResponse<TBaseDtoRequest>> Store(TBaseDtoRequest entity);

    

    public  Task<AtlasMixedResponse<TBaseDtoResponse>> Update(TBaseDtoRequest dto, int id);

    public Task<AtlasMixedResponse<TBaseDtoResponse>> Edit(int id);

    public Task<TBaseEntity> Edit(TBaseEntity entity, int id);



    public Task<bool> delete(TBaseEntity entity);

    public Task<bool> delete(int id);

}
