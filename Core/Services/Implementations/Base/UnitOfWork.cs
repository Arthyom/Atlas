using System;
using Core.Models.Context;
using Core.Models.Entities.BaseEntity;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;

namespace Core.Services.Implementations.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appContext;
    private Dictionary<Type, object> _repos;
    private bool _disposed;


    public UnitOfWork(AppDbContext appDbContext)
    {
        _appContext = appDbContext;
        _repos = new Dictionary<Type, object>();
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IBaseRepository<TEntity> GetRepo<TEntity>() where TEntity : BaseEntity
    {
        if (_repos.ContainsKey(typeof(TEntity)))
            return (IBaseRepository<TEntity>)_repos[typeof(TEntity)];

        IBaseRepository<TEntity> newRepo = new BaseRepository<TEntity>(_appContext);
        _repos.Add(typeof(TEntity), newRepo);
        return newRepo;
    }


    public int SaveChanges()
    {
        // return _appContext.SaveChanges();
       return 0;
    }

    public async Task<int> SaveChangesAsync()
    {
        //   return await _appContext.SaveChangesAsync();
        return await Task.FromResult(0);
    }



    public void Commit()
    {
      //  _appContext.Database.CommitTransaction();
    }

    public async Task CommitAsync()
    {
      //  await _appContext.Database.CommitTransactionAsync();
    }



    public void Begin()
    {
       // _appContext.Database.BeginTransaction();
    }

    public async Task BeginAsync()
    {
        //await _appContext.Database.BeginTransactionAsync();
    }



    public void RollBack()
    {
        //_appContext.Database.RollbackTransaction();
    }

    public async Task RollBackAsync()
    {
       // await _appContext.Database.RollbackTransactionAsync();
    }



    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {

            }
        }
        _disposed = true;

    }


}
