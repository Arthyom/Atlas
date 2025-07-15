using System;
using Core.Models.Entities.BaseEntity;

namespace Core.Services.Interfaces.Base;

public interface ISeederFacade<TBaseEntity> where TBaseEntity : BaseEntity
{
    	public void Seed();

}
