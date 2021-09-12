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
            //CreateMap<Employee, EmployeeDTO>()
            //    .ForMember(dest => dest.Role, src => src.MapFrom(src => src.RoleId))
            //    .ForMember(dest => dest.Picture, src => src.MapFrom(src => src.PicturePath)); 
            //CreateMap<EmployeeDTO, Employee>()
            //    .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role))
            //    .ForMember(dest => dest.PicturePath, src => src.MapFrom(src => src.Picture))
            //    .ForMember(dest => dest.Gender, src => src.MapFrom(src => src.Pol)); 
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email))
                    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role));

            CreateMap<SEDC_WebApplicationEntityFactory.Entities.Employee, EmployeeDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.RoleId))
                 .ForMember(dest => dest.Name, src => src.MapFrom(src => src.EmployeeName));

            CreateMap<EmployeeDTO, SEDC_WebApplicationEntityFactory.Entities.Employee>()
                .ForMember(dest => dest.EmployeeName, src => src.MapFrom(src => src.Email))
                    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role))
                        .ForMember(dest => dest.Role, src => src.Ignore());


            //CUSTOMER
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.CustomerContactId, src => src.MapFrom(src => src.ContactId))
                .ForMember(dest => dest.PicturePath, src => src.MapFrom(src => src.PicturePath));
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.CustomerName, src => src.MapFrom(src => src.Name))
                //.ForMember(dest => dest.Address, src => src.MapFrom(src => src.Address))
                .ForMember(dest => dest.ContactId, src => src.MapFrom(src => src.CustomerContactId))
                .ForMember(dest => dest.PicturePath, src => src.MapFrom(src => src.PicturePath));

            CreateMap<SEDC_WebApplicationEntityFactory.Entities.Customer, CustomerDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.CustomerName))
                 .ForMember(dest => dest.CustomerContactId, src => src.MapFrom(src => src.ContactId));

            CreateMap<CustomerDTO, SEDC_WebApplicationEntityFactory.Entities.Customer>()
                .ForMember(dest => dest.CustomerId, src => src.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CustomerName, src => src.MapFrom(src => src.Name))
                        .ForMember(dest => dest.ContactId, src => src.Ignore());


            //PRODUCT
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Price, src => src.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.ImagePath, src => src.MapFrom(src => src.PicturePath));
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsDiscounted, src => src.MapFrom(src => src.Discounted))
                .ForMember(dest => dest.IsActive, src => src.MapFrom(src => src.Active))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.PicturePath, src => src.MapFrom(src => src.ImagePath));

            CreateMap<SEDC_WebApplicationEntityFactory.Entities.Product, ProductDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Price, src => src.MapFrom(src => src.UnitPrice));

            CreateMap<ProductDTO, SEDC_WebApplicationEntityFactory.Entities.Product>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(src => src.Price)); ;
        }
    }
}
