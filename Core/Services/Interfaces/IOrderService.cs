using System;
using Core.DTOs;
using Core.Models.Entities;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces;

public interface IOrderService : IAtlasBaseServiceMixed<Order, DtoOrder, DtoOrderResponse>
{

    
}
