using System;
using AutoMapper;
using Core.DTOs.Customer;
using Core.Models.Entities;

namespace Core.Mappers;

public class ProfileCustomer : Profile
{
    public ProfileCustomer()
    {
        CreateMap<Customer, DtoCustomerResponse>()
        .ReverseMap();

        CreateMap<Customer, DtoCustomerRequest>()
        .ReverseMap();
    }

}
