using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Paquete;
using Core.Models.Entities;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;

namespace Core.Services.Implementations
{
    public class PaqueteMixedService : AtlasBaseServiceMixed<Paquete, DtoPaqueteRequest, DtoPaqueteResponse>, IPaqueteMixedService
    {
        public PaqueteMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
        {
        }
    }
}