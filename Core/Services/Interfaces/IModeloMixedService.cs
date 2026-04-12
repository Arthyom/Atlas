using System;
using Core.DTOs.Modelo;
using Core.Models.Entities;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces;

public interface IModeloMixedService : IAtlasBaseServiceMixed<Modelo, DtoModeloRequest, DtoModeloResponse>
{

}
