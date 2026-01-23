using System;
using AutoMapper;
using Core.DTOs.Direccion.Destino;
using Core.DTOs.Direccion.Origen;
using Core.Models.Entities;

namespace Core.Resolvers;

public class AtlasResolverOrigen : IValueResolver<Direccion, Origen, Origen>
{
    public Origen Resolve(Direccion source, Origen destination, Origen destMember, ResolutionContext context)
    {
        return new Origen()
        {
            DireccionId = source.Id,
            Direccion = source
        };
    }
}

public class AtlasResolverDestino : IValueResolver<Direccion, Destino, Destino>
{
    public Destino Resolve(Direccion source, Destino destination, Destino destMember, ResolutionContext context)
    {
        return new Destino()
        {
            DireccionId = source.Id,
            Direccion = source
        };
    }
}

public class AtlasResolverDestinoApiResponse : IMemberValueResolver<Origen, DtoApiEnPeOrigenResponse, Origen, DtoApiEnPeOrigenResponse>
{
    public DtoApiEnPeOrigenResponse Resolve(Origen source, DtoApiEnPeOrigenResponse destination, Origen sourceMember, DtoApiEnPeOrigenResponse destMember, ResolutionContext context)
    {
        throw new NotImplementedException();
    }
}


public class AtlasResolverOrigenApiResponse : IValueResolver<Origen, DtoApiEnPeOrigenResponse, DtoApiEnPeOrigenResponse>
{
    public DtoApiEnPeOrigenResponse Resolve(Origen source, DtoApiEnPeOrigenResponse destination, DtoApiEnPeOrigenResponse destMember, ResolutionContext context)
    {
       return new DtoApiEnPeOrigenResponse()
       {
           
       };
    }
}


public class AtlasResolverEnvioApiResponse : IValueResolver<Envio, DtoApiEnPeOrigenResponse, DtoApiEnPeOrigenResponse>
{

    // object IValueResolver<Envio, DtoApiEnPeOrigenResponse, object>.Resolve(Envio source, DtoApiEnPeOrigenResponse destination, object destMember, ResolutionContext context)
    // {
    //     return Resolve(source, destination, destMember, context);
    // }
    public DtoApiEnPeOrigenResponse Resolve(Envio source, DtoApiEnPeOrigenResponse destination, DtoApiEnPeOrigenResponse destMember, ResolutionContext context)
    {
        return new DtoApiEnPeOrigenResponse()
        {
            
        };
    }
}