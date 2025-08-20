using System;
using Core.Models.Entities.Base;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Implementations.Base;


public class BaseService<TBaseEntity> : IBaseService<TBaseEntity> where TBaseEntity : BaseEntity
{

    private readonly IUnitOfWork _UoW;
    protected readonly IBaseRepository<TBaseEntity> _BaseRepository;



    public IUnitOfWork UoW => _UoW;
    public IBaseRepository<TBaseEntity> repo => _BaseRepository;



    public BaseService(IUnitOfWork UoW)
    {
        _UoW = UoW;
        _BaseRepository = _UoW.GetRepo<TBaseEntity>();
    }



    public Task<TBaseEntity> Create(TBaseEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> delete(TBaseEntity entity)
    {
        throw new NotImplementedException();
    }
    public Task<bool> delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TBaseEntity> Edit(TBaseEntity entity, int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TBaseEntity>> GetAll()
    {
       return await _BaseRepository.DbSet.ToListAsync();
    }

    public Task<TBaseEntity> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
