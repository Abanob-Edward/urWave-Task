using AutoMapper;
using Product_Management_System.Dtos.Product;
using Product_Management_System.Models;
using Product_Management_System.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_System.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<AddOrUpdateProductDto, Product>().ReverseMap();
            CreateMap<AddOrUpdateProductDto, ProductDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
