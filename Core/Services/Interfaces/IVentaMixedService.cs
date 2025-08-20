using System;
using Core.DTOs.Venta;
using Core.Models.Entities;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces;

public interface IVentaMixedService : IAtlasBaseServiceMixed<Venta, DtoVentaRequest, DtoVentaResponse>
{

}
