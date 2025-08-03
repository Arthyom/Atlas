using System;
using Atlas.Core.Entities;
using Core.DTOs;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces;

public interface IProductoMixedService : IAtlasBaseServiceMixed<Producto, DtoProductoRequst, DtoProductoResponse>
{

    public  Task <byte []> GetCodes( DtoProductoBarCodeRequest codes ); 
}
