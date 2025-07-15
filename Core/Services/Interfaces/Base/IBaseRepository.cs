using System;
using Core.Models.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Interfaces.Base;

public interface IBaseRepository<T> where T : BaseEntity
{
    DbSet<T> DbSet { get; }
        
    void Insert(T entity);
    void Update(T entity);


    void Delete(object id);
    void Delete(T entity);
}
