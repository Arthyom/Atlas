using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Guia;
using Core.DTOs.Guias;
using Core.Models.Entities;
using Core.Services.Interfaces.Base;

namespace Core.Services.Interfaces
{
    public interface IGuideMixedService : IAtlasBaseServiceMixed<Guide, DtoGuiaRequest, DtoGuiaResponse>
    {
        
    }
}