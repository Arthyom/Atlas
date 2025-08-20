using System;
using Core.Models.Entities.Base;

namespace Core.Services.Interfaces.Base;

public interface IBaseService<TBaseEntity> where TBaseEntity : BaseEntity
{


    public IUnitOfWork UoW { get; }
    public IBaseRepository<TBaseEntity> repo { get; }





    public Task<List<TBaseEntity>> GetAll();

    public Task<TBaseEntity> GetById(int id);



    public Task<TBaseEntity> Create(TBaseEntity entity);
    public Task<TBaseEntity> Edit(TBaseEntity entity, int id);



    public Task<bool> delete(TBaseEntity entity);
        public Task<bool> delete(int id);


}
