using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Paquete;
using Core.Models.Entities;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces
{
    
    public interface IPaqueteMixedService : IAtlasBaseServiceMixed<Paquete, DtoPaqueteRequest, DtoPaqueteResponse>
    {
        
    }
}