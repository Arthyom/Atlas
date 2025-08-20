using System;
using AutoMapper;
using Core.DTOs.Venta;
using Core.Models.Entities;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;

namespace Core.Services.Implementations;

public class VentaMixedService : AtlasBaseServiceMixed<Venta, DtoVentaRequest, DtoVentaResponse>, IVentaMixedService
{
    public VentaMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
    {
    }
}
