using AutoMapper;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.DAL.Data.Entities;
using SEDC_WebApplication.Models;
using System;

namespace SEDC_WebApplication.BLL.Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email));

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email));

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(src => src.Id));
        }
    }
}
