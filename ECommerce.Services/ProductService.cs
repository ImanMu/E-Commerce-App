using AutoMapper;
using ECommerce.DTOs.DTOs.Product;
using ECommerce.Models;
using ECommerce.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Services
{
    public class ProductService : IProductService
	{
        IProductRepository ProductRepository;
        IMapper Mapper;
        public ProductService(IProductRepository _productRepository, IMapper _mapper)
        {
			ProductRepository = _productRepository;
            Mapper= _mapper;
        }

		public List<GetAllProductsDTO> GetAll( int? category)
        {
			if (category == null)
			{
				var Products = ProductRepository.GetAll().ToList();
				var ProductsDTO = Mapper.Map<List<GetAllProductsDTO>>(Products);
				return ProductsDTO;
			}
			else
            {
				var Products = ProductRepository.GetAll().Where(p => p.CategoryId == category).ToList();
				if (!Products.Any()) 
				{
					throw new Exception($"Category with Id '{category}' not found.");

				}
				var ProductsDTO = Mapper.Map<List<GetAllProductsDTO>>(Products);
				return ProductsDTO;
			}
		}
        public GetAllProductsDTO GetOne(int Id)
        {
            var Product = ProductRepository.GetAll().Where(p => p.ProductId == Id).FirstOrDefault();
            if (Product == null)
            {
                return null; 
            }

            var ProductDTO = Mapper.Map<GetAllProductsDTO>(Product);
            return ProductDTO;

        }
        public bool Create(CreateOrUpdateProductDTO p)
        {
            var AlreadyExist = ProductRepository.GetAll().FirstOrDefault(P => P.ProductName == p.ProductName);
            if (AlreadyExist != null) 
            {
                return false;
            }
            Product product = Mapper.Map<Product>(p);
			ProductRepository.Create(product);
            return true; 
        }
        public bool Update(int Id, CreateOrUpdateProductDTO p)
        {
            var UpdatedProduct = ProductRepository.GetAll().Where(p => p.ProductId == Id).FirstOrDefault();
            if (UpdatedProduct == null)
            {
                return false;
            }
            else
            {
                Mapper.Map(p, UpdatedProduct);
				ProductRepository.Update(UpdatedProduct);
                return true;
            }
        }
        public bool Delete(int Id)
        {
            var DeletedProduct = ProductRepository.GetAll().Where(p => p.ProductId == Id).FirstOrDefault();
            if (DeletedProduct == null)
            {
                return false;
            }
            else
				ProductRepository.Delete(DeletedProduct);
                return true;
        }
    }
}
