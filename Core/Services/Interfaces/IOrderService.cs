using System;
using Core.DTOs;
using Core.DTOs.Base;
using Core.DTOs.Shared;
using Core.Models.Entities;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces;

public interface IOrderService : IAtlasBaseServiceMixed<Order, DtoSharedApiEnvioOrdenRequest, DtoOrderResponse>
{

    
}
