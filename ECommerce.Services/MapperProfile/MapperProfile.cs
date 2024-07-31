using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.DTOs.DTOs.Category;
using ECommerce.DTOs.DTOs.Order;
using ECommerce.DTOs.DTOs.Product;
using ECommerce.Models;

namespace ECommerce.Services.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
			CreateMap< Product, CreateOrUpdateProductDTO>().ReverseMap();
			CreateMap< Product, GetAllProductsDTO>()
			//.ForMember(dest => dest.CategoryId, opt => opt.Ignore())
			.ReverseMap();

			CreateMap<CreateOrUpdateCategoryDTO, Category>().ReverseMap();
			CreateMap<GetAllCategoriesDTO, Category>().ReverseMap();


			CreateMap<CreateOrderDTO, Order>().ReverseMap();
			CreateMap<UpdateOrderDTO, Order>().ReverseMap();
			CreateMap<GetAllOrdersDTO, Order>().ReverseMap();
		}
    }
}
