using System;
using Core.Models.Context;
using Core.Models.Entities.BaseEntity;
using Core.Services.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Implementations.Base;


public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public DbSet<T> DbSet => _dbSet;

    private AppDbContext _appDbContext;
    private DbSet<T> _dbSet;

    public BaseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        // _dbSet = _appDbContext.Set<T>();
    }

    public virtual void Insert(T entity)
    {
        // _appDbContext.Add(entity);
    }

    public virtual void Update(T entity)
    {
        // _dbSet.Attach(entity);
        // _appDbContext.Entry(entity).State = EntityState.Modified;
    }


    public virtual void Delete(object id)
    {
        var toDel = _dbSet.Find(id) ?? throw new Exception("");
        Delete(toDel);
    }

    public virtual void Delete(T entity)
    {
        // if (_appDbContext.Entry(entity).State == EntityState.Detached)
        // {
        //     _dbSet.Attach(entity);
        // }
        // _dbSet.Remove(entity);
    }

}
