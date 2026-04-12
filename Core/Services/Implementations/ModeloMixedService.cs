using System;
using AutoMapper;
using Core.DTOs.Modelo;
using Core.Models.Entities;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;

namespace Core.Services.Implementations;

public class ModeloMixedService : AtlasBaseServiceMixed<Modelo, DtoModeloRequest, DtoModeloResponse>, IModeloMixedService
{
    public ModeloMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
    {
    }
}
