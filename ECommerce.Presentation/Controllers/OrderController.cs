using ECommerce.DTOs.DTOs.Order;
using ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		IOrderService OrderService;
		public OrderController(IOrderService _OrderService)
		{
			OrderService = _OrderService;
		}

		[HttpGet]
		//[Authorize(Roles = "Admin")]
		public IActionResult GetAll()
		{
			var Orders = OrderService.GetAll();
			return Ok(Orders);
		}
		[HttpPost]
		//[Authorize(Roles = "User")]
		public IActionResult Create(CreateOrderDTO o)
		{
			var result = OrderService.Create(o);
			if (result)
				return Ok("the Order was successfuly created");
			else
				return StatusCode(500, "Add Products Please");
		}

		[HttpPut]
		[Route("{Id}")]
		//[Authorize(Roles = "Admin")]
		public IActionResult Update(int Id, UpdateOrderDTO o)
		{
			var UpdatedOrder = OrderService.Update(Id, o);
			if (UpdatedOrder)
			{
				return Ok("the Order was successfully Edited");
			}
			else
				return NotFound("Order not found");
		}
		[HttpDelete]
		[Route("{Id}")]
		//[Authorize(Roles = "Admin")]
		public IActionResult Delete(int Id)
		{
			var DeletedOrder = OrderService.Delete(Id);
			if (DeletedOrder)
			{
				return Ok("the Order was successfully Deleted");
			}
			else
				return NotFound("Order not found");

		}
	}
}
