using System;
using System.Reflection;
using Atlas.Core.Entities;
using Core.Models.Context;
using Core.Models.Entities.BaseEntity;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Core.Enums.Constants;

namespace Core.Services.Implementations.Base;




public class SeederFacade<TBaseEntity> : ISeederFacade<TBaseEntity> where TBaseEntity : BaseEntity
{
    private readonly AtlasDbContext _appContext;
    private readonly IUnitOfWork _unitOfWork;
    public SeederFacade(AtlasDbContext AtlasAppDbContext, IUnitOfWork unitOfWork)
    {
        _appContext = AtlasAppDbContext;
        _unitOfWork = unitOfWork;
    }


    public void Seed()
    {
        try
        {
            string entityName = typeof(TBaseEntity).Name;
            string documentName = $"{entityName}.json";
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = Path.Combine(Path.GetDirectoryName(assembly.Location) ?? "", "Seeder", "Data", documentName);

            var jsonAsText = File.ReadAllText(resourceName) ?? throw new Exception("No File readed");
            var seederList = JsonConvert.DeserializeObject<List<TBaseEntity>>(jsonAsText);

            if (seederList != null)
            {
                if (seederList.Any())
                {
                    var repo = _unitOfWork.GetRepo<TBaseEntity>();
                   _unitOfWork.Begin();
                    SetIdentityTo(entityName, AtlasIdentityState.On);

                    seederList.ForEach(x =>
                    {
                        if (!repo.DbSet.Where(z => z.Id == x.Id).Any())
                        {
                            var added = repo.DbSet.Add(x);


                            if (added == null)
                                throw new Exception("Error seeding data");
                                                    _unitOfWork.SaveChanges();

                        }
                    });
                    
                    SetIdentityTo(entityName, AtlasIdentityState.Off);
                    _unitOfWork.SaveChanges();
                   _unitOfWork.Commit();
                }
            }
        }
        catch (System.Exception ex)
        {
            _unitOfWork.RollBack();
            throw new Exception(ex.Message, ex);
        }
    }

    public void SetIdentityTo( string TableName,  AtlasIdentityState state  = AtlasIdentityState.On)
    {
        if (!SeederInsertExceptions.Contains(TableName))
        {     
            string sql = $"SET IDENTITY_INSERT [dbo].[{TableName}] {state}";
            _appContext.Database.ExecuteSqlRaw(sql);
        }
    }
}