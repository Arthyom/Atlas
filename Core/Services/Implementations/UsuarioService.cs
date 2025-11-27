using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;

namespace Core.Services.Implementations
{
    public class UsuarioMixedService : AtlasBaseServiceMixed<Usuario, DtoUsuario, DtoUsuario>, IUsuarioMixedService
    {
        public UsuarioMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
        {
        }


        
    }
}