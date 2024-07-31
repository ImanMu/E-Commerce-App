using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Services;
using ECommerce.DTOs.DTOs.Category;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{ 
		ICategoryService CategoryService;
		public CategoryController(ICategoryService _categoryService)
		{
			CategoryService = _categoryService;
		}

		[HttpGet]
		//[Authorize(Roles = "Admin")]
		public IActionResult GetAll()
		{
			var Categorys = CategoryService.GetAll();
			return Ok(Categorys);
		}
		[HttpPost]
		//[Authorize(Roles = "Admin")]
		public IActionResult Create(CreateOrUpdateCategoryDTO u)
		{
			var result = CategoryService.Create(u);
			if (result)
				return Ok("the Category was successfuly created");
			else
				return StatusCode(500, "a Category with the same name already exists");
		}

		[HttpPut]
		[Route("{Id}")]
		//[Authorize(Roles = "Admin")]
		public IActionResult Update(int Id, CreateOrUpdateCategoryDTO c)
		{
			var UpdatedCategory = CategoryService.Update(Id, c);
			if (UpdatedCategory)
			{
				return Ok("the Category was successfully Edited");
			}
			else
				return NotFound("Category not found");
		}
		[HttpDelete]
		[Route("{Id}")]
		//[Authorize(Roles = "Admin")]
		public IActionResult Delete(int Id)
		{
			var DeletedCategory = CategoryService.Delete(Id);
			if (DeletedCategory)
			{
				return Ok("the Category was successfully Deleted");
			}
			else
				return NotFound("Category not found");

		}
	}
}
