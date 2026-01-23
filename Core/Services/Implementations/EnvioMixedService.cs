using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.DTOs.Base;
using Core.DTOs.Envio;
using Core.DTOs.Orden;
using Core.Models.Entities;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Core.Services.Implementations
{
    public class EnvioMixedService : AtlasBaseServiceMixed<Envio, DtoApiEnPeEnvioRequest , DtoApiEnPeEnvioResponse>, IEnvioMixedService
    {
        public EnvioMixedService(IUnitOfWork UoW, IMapper mapper) : base(UoW, mapper)
        {
        }


        public override async Task<AtlasMixedResponse<DtoApiEnPeEnvioResponse>> GetAll()
        {
            try
            {

            var respo = new AtlasMixedResponse<DtoApiEnPeEnvioResponse>();

            var mainCollection = await UoW.GetRepo<Envio>()
                .DbSet
                .Include(x => x.Origen.Direccion)
                .Include( x => x.Destino.Direccion)
                .Include( x => x.Order)
                .Include(x => x.Order.Productos)
                .Include( x => x.Paquete)
                // .ProjectTo<DtoApiEnPeEnvioResponse>(_Mapper.ConfigurationProvider)
                
                .ToListAsync();


            // respo.MainResourceCollection =  new List< DtoProductoResponse >().tolis ///await _BaseRepository.DbSet.ToListAsync();
            var assembly = Assembly.GetExecutingAssembly();

            // var resourceName = Path.Combine(Path.GetDirectoryName(assembly.Location) ?? "", "Seeder", "Data", "Envios.json");

            // var jsonAsText = File.ReadAllText(resourceName) ?? throw new Exception("No File readed");
            // var seederList = JsonConvert.DeserializeObject<List<Envio>>(jsonAsText);

            // var mapped = _Mapper.Map<DtoApiEnPeEnvioResponse>(seederList);

            // Envio e = new Envio()
            // {
            //     CreatedAt = DateTime.Now,
            //     DeliveryType= "Tipo 1",
            //     DestinationId = 1001,
            //     Id = 2002,
            //     Status = Enums.AtlasEnumShippingStatus.InTransit,
            //     Destino = new Destino()
            //     {
            //         Id = 1001,
            //         CreatedAt= DateTime.Now,
            //         DireccionId = 1001,
            //         Direccion = new Direccion()
            //         {
            //             Id = 1001,
            //             Company = "Company Destino",
            //             Street = "Street Destino",
            //             City = "City Destino",
            //             State = "State Destino",
            //             ZipCode = "12345",
            //             Name = "John Doe",
            //             Email = "a.gonzalez",
            //             Phone = "555-1234",
            //             InteriorNumber = "10",
            //             OutdoorNumber = "20",
            //             Neighborhood = "Neighborhood Destino",
            //             References = "Near the park"
            //         }
            //     },
            //     Origen = new Origen()
            //     {
            //         Id = 2002,
            //         CreatedAt = DateTime.Now,
            //         DireccionId = 2002,
            //         Direccion = new Direccion()
            //         {
            //             Id = 2002,
            //             Company = "Company Origen",
            //             Street = "Street Origen",
            //             City = "City Origen",
            //             State = "State Origen",
            //             ZipCode = "67890",
            //             Name = "Jane Smith",
            //             Email = "j.smith",
            //             Phone = "555-5678",
            //             InteriorNumber = "30",
            //             OutdoorNumber = "40",
            //             Neighborhood = "Neighborhood Origen",
            //             References = "Next to the mall"
            //         }
            //     },
            //     PackageId = 3003,
            //     Paquete = new Paquete()
            //     {
            //         Id = 3003,
            //         CreatedAt = DateTime.Now,
            //         Weight = "2.5",
            //         Depth = "30.0",
            //         Width = "20.0",
            //         Height = "15.0",
            //         Description = "Electronics"
            //     }
            // };

            // var em = _Mapper.Map< DtoApiEnPeEnvioResponse>(e);

            // mainCollection.Add( em );

            var mappedList = _Mapper.Map<List<DtoApiEnPeEnvioResponse>>(mainCollection);

            respo.MainResourceCollection = mappedList;


            return await Task.FromResult(respo);



            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

        }

        public  async Task<Guide> GetShippingGuide(string identifier)
        {
            return await Task.FromResult( new Guide()
            {
                ApiId = Guid.NewGuid().ToString(),
                Info = File.ReadAllBytes("/home/frodo/Downloads/test.pdf")
            }); 
        }

        public async Task<AtlasMixedResponse<DtoApiEnPeShippingProviderResponse>> GetShippingProviders()
        {
            return await Task.FromResult( new AtlasMixedResponse<DtoApiEnPeShippingProviderResponse>()
            {
               MainResourceCollection = new List<DtoApiEnPeShippingProviderResponse>()
               {
                   new DtoApiEnPeShippingProviderResponse()
                   {
                       Title = "Title example",
                       Cost = 234.33,
                       Currency = "MXN",
                       DeliveryType = new DtoApiEnPeDeliveryTypeResponse
                       {
                           Company = "Test",
                           Description = "Test",
                           Feature = "test",
                           Name = "Test name"
                       },
                       PackageSize = "Box",
                       Pickup = true
                   }
               }
            });
        }
    }
}