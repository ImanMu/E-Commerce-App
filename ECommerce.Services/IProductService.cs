using ECommerce.DTOs.DTOs.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public interface IProductService
    {
        List<GetAllProductsDTO> GetAll(int? category);
		GetAllProductsDTO GetOne(int Id);
        bool Create(CreateOrUpdateProductDTO p);
        bool Update(int Id, CreateOrUpdateProductDTO p);
        bool Delete(int Id);
    }
}
