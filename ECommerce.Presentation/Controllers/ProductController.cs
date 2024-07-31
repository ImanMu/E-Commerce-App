using ECommerce.DTOs.DTOs.Product;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{   
		IProductService ProductService;
		public ProductController(IProductService _ProductService)
		{
			ProductService = _ProductService;
		}

		[HttpGet]
		[Route("Categories/{category?}")]
		//[Authorize(Roles = "User")]
		public IActionResult GetAll( int? category)
		{
			var Products = ProductService.GetAll(category);
			return Ok(Products);
		}

		[HttpGet]
		[Route("{Id}")]
		//[Authorize(Roles = "Admin")]
		public IActionResult GetOne(int Id)
		{
			var Product = ProductService.GetOne(Id);
			if (Product == null)
			{
				return NotFound();
			}
			else
				return Ok(Product);
		}
		[HttpPost]
		//[Authorize(Roles = "Admin")]
		public IActionResult Create(CreateOrUpdateProductDTO p)
		{
			var result = ProductService.Create(p);
			if (result)
				return Ok("the Product was successfuly created");
			else
				return StatusCode(500, "a Product with the same name already exists");
		}

		[HttpPut]
		[Route("{Id}")]
		//[Authorize(Roles = "Admin")]
		public IActionResult Update(int Id, CreateOrUpdateProductDTO p)
		{
			var UpdatedProduct = ProductService.Update(Id, p);
			if (UpdatedProduct)
			{
				return Ok("the Product was successfully Edited");
			}
			else
				return NotFound("Product not found");
		}
		[HttpDelete]
		[Route("{Id}")]
		//[Authorize(Roles = "Admin")]
		public IActionResult Delete(int Id)
		{
			var DeletedProduct = ProductService.Delete(Id);
			if (DeletedProduct)
			{
				return Ok("the Product was successfully Deleted");
			}
			else
				return NotFound("Product not found");

		}
	}
}
