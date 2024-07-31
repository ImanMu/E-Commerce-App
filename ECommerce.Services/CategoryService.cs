using AutoMapper;
using ECommerce.DTOs.DTOs.Category;
using ECommerce.Models;
using ECommerce.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Services
{
    public class CategoryService : ICategoryService
	{
		ICategoryRepository CategoryRepository;
		IMapper Mapper;
		public CategoryService(ICategoryRepository _categoryRepository, IMapper _mapper)
		{
			CategoryRepository = _categoryRepository;
			Mapper = _mapper;
		}
		public List<GetAllCategoriesDTO> GetAll()
		{
			var Category = CategoryRepository.GetAll().ToList();
			var CategoryDTO = Mapper.Map<List<GetAllCategoriesDTO>>(Category);
			return CategoryDTO;
		}
		public bool Create(CreateOrUpdateCategoryDTO c)
		{
			var AlreadyExist = CategoryRepository.GetAll().FirstOrDefault(C => C.CategoryName == c.CategoryName);
			if (AlreadyExist != null)
			{
				return false;
			}
			Category category = Mapper.Map<Category>(c);
			CategoryRepository.Create(category);
			return true;
		}
		public bool Update(int Id, CreateOrUpdateCategoryDTO c)
		{
			var CategoryToUpdate = CategoryRepository.GetAll().Where(c => c.CategoryId == Id).FirstOrDefault();
			if (CategoryToUpdate == null)
			{
				return false;
			}
			else
			{
				Mapper.Map(c, CategoryToUpdate);
				CategoryRepository.Update(CategoryToUpdate);
				return true;
			}
		}
		public bool Delete(int Id)
		{
			var DeletedCategory = CategoryRepository.GetAll().Where(c => c.CategoryId == Id).FirstOrDefault();
			if (DeletedCategory == null)
			{
				return false;
			}
			else
				CategoryRepository.Delete(DeletedCategory);
			return true;
		}
	}
}
