using System;
using Core.Models.Entities.BaseEntity;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces;

public interface IUnitOfWork : IDisposable
{

    IBaseRepository<TEntity> GetRepo<TEntity>() where TEntity : BaseEntity;

    int SaveChanges();
    Task<int> SaveChangesAsync();

    void Commit();
    Task CommitAsync();


    void Begin();
    Task BeginAsync();


    
    void RollBack();
    Task RollBackAsync();

}
