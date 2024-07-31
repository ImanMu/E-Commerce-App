using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs.DTOs.Order
{
	public class OrderProductDTO
	{
		public int ProductId { get; set; }
		[Range(0, 10, ErrorMessage = "Quantity must be between 1 and 10 items")]
		public int Quantity { get; set; }
	}
}
