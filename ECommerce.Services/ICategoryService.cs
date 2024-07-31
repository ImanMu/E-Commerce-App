using ECommerce.DTOs.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public interface ICategoryService
    {
        List<GetAllCategoriesDTO> GetAll();
        bool Create(CreateOrUpdateCategoryDTO c);
        bool Update(int Id, CreateOrUpdateCategoryDTO c);
        bool Delete(int Id);
    }
}
