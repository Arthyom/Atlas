using System;
using Atlas.Core.Entities;
using Core.DTOs;
using Core.DTOs.Api.Response;
using Core.DTOs.Customer;
using Core.DTOs.Direccion.Destino;
using Core.DTOs.Direccion.Origen;
using Core.DTOs.Envio;
using Core.DTOs.Shared;
using Core.Models.Entities;

namespace Core.Seeder.Data;

public static class OrderData
{
    public static List<DtoSharedApiEnvioOrdenRequest> OrdersData = new()
    {
        new DtoSharedApiEnvioOrdenRequest()
        {
            ApiAcountId = "Api-Account-Id-101010",
            ApiCustomerId = "Api-customer-id-1000",
            ApiId= "Api-Id-628920",
            ApiNumber= "Api-Number-10000495",
            ApiStatus = "Api-Status-Created",
            ApiType = "Apy-Type-Test",
            Currency = "MXN",
            // email = "allpipiaaa@gmmail.com",
            // first_name = "first-name-test",
            // last_name = "last-name-test",
            // phone = "phone-test-34343434",
            folio = "folio-test-34343434",  
            



            // Customer = new DtoCustomerResponse()
            // {
            //     ApiCustomerId = "Api-customer-id-1000",
            //     Email = "allpipiasaaa@gmails.com",
            //     FirtName ="customer-fistname-Test",
            //     LastName="Customer-last-name-test",
            //     Phone = "customerr-phone",
                
            // },
            // Direccion = new Direccion()
            // {
            //     City = "City-Order-Id",
            //     Company = "Company-test",
            //     CountryCode = "MX",
            //     CountryName = "Mexico",
            //     Email = "Allpipiasaa@gmeil.com",
            //     InteriorNumber = "address-iner-num"
            // },
            // Address = new DtoApiECartAddressResponse()
            // {

            //  address1 = "Addres test 1",
            //  address2 = "Addres test 2",
            //  city = "Citye test",
            //  country = new DtoApiECartPaisRequest()
            //  {
            //      code = "MX",
            //      name = "MExico"
            //  } 
            // },
            items = new List<DtoProductoRequst>()
            {
              new DtoProductoRequst()
              {
                Id = 1413,
                Nombre = "Producto test 1",
                PrecioUnitario = 150.00M
              },
              new DtoProductoRequst()
              {
                  Id = 1413,
                  Nombre = "Producto test 2",
                  PrecioUnitario = 250.00M
              }
            },

            Customer = new DtoCustomerRequest()
            {
                       email = "allpipiaaa@gmmail.com",
            first_name = "first-name-test",
            last_name = "last-name-test",
            phone = "phone-test-34343434"
            ,
            },

            envios = new List<DtoApiEnPeEnvioRequest>()
            {
                new DtoApiEnPeEnvioRequest()
                {
                    Paquete = new DTOs.Paquete.DtoPaqueteRequest()
                    {
                        Height = "10",
                        Depth = "20",
                        Weight = "5",
                        Width = "15",
                        Description = "content-description-test",
                        Type = "box"
                    },
                    Origen = new DtoApiEnPeOrigenRequest()
                    {
                        company_origin = "company-origin",
                        street_origin = "street-origin",
                        interior_number_origin = "interior-number-origin",
                        outdoor_number_origin = "outdoor-number-origin",
                        zip_code_origin = "zip-code-origin",
                        neighborhood_origin = "neighborhood-origin",
                        city_origin = "city-origin",
                        state_origin = "state-origin",
                        references_origin = "references-origin",
                        name_origin = "name-origin",
                        email_origin = "email-origin",
                        phone_origin = "phone-origin",
                        save_origin = "save-origin"
                    },
                    Destino = new DtoApiEnPeDestinoRequest()
                    {
                        company_dest = "company-dest",
                        street_dest = "street-dest",
                        interior_number_dest = "interior-number-dest",
                        outdoor_number_dest = "outdoor-number-dest",
                        zip_code_dest = "zip-code-dest",
                        neighborhood_dest = "neighborhood-dest",
                        city_dest = "city-dest",
                        state_dest = "state-dest",
                        references_dest = "references-dest",
                        name_dest = "name-dest",
                        email_dest = "email-dest",
                        phone_dest = "phone-dest",
                        save_dest = "save-dest",
                        country_code_dest = "MX",
                        country_code_name = "Mexico",
                        state_code_dest = "SLP"
                    }
                }
            }
        }
    };
}
