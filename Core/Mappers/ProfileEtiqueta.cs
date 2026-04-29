using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Etiqueta;
using Core.Models.Entities;

namespace Core.Mappers
{
    public class ProfileEtiqueta : Profile
    {
        public ProfileEtiqueta()
        {
                        CreateMap<Etiqueta, DtoEtiquetaResponse>()
                        .ReverseMap();

            // CreateMap<Etiqueta, DtoEtiquetaResponse?>()
            // .ConvertUsing( src => fixEtiqueta(src))
            
            // ;
        }

        private static DtoEtiquetaResponse? fixEtiqueta( Etiqueta et)
        {
            if(et.EtiquetaId != null)
            {
                return null;
            }

            return new DtoEtiquetaResponse()
            {
                CreatedAt = et.CreatedAt,
                Descripcion = et.Descripcion,


                Existencia= et.Existencia,
                ExistenciaMaxima = et.ExistenciaMaxima,
                ExistenciaMinima = et.ExistenciaMaxima,
                Id = et.Id,
                Nombre = et.Nombre,
                PrecioMayoreo = et.PrecioMayoreo,
                PrecioUnitario = et.PrecioUnitario

            };
        }
    }
}