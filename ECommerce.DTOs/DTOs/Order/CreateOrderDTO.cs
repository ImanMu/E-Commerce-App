using ECommerce.DTOs.Validations;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs.DTOs.Order
{
	public class CreateOrderDTO
	{
		public int CustomerId { get; set; }
		public List<OrderProductDTO> Products { get; set; } 
		//public CreateOrderDTO()
		//{
		//	Products = new List<OrderProductDTO>(); 
		//}

	}
}
