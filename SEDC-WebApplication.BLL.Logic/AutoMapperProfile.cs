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
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.Picture, src => src.MapFrom(src => src.PicturePath)); 
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role))
                .ForMember(dest => dest.PicturePath, src => src.MapFrom(src => src.Picture))
                .ForMember(dest => dest.Gender, src => src.MapFrom(src => src.Pol)); 

            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.CustomerContactId, src => src.MapFrom(src => src.ContactId));
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.CustomerName, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.ContactId, src => src.MapFrom(src => src.CustomerContactId))
                .ForMember(dest => dest.PicturePath, src => src.MapFrom(src => src.PicturePath));

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Price, src => src.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.ImagePath, src => src.MapFrom(src => src.PicturePath));
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(src => src.Price))
                .ForMember(dest => dest.PicturePath, src => src.MapFrom(src => src.ImagePath));

        }
    }
}
