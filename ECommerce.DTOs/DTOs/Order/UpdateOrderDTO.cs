using ECommerce.DTOs.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs.DTOs.Order
{
	public class UpdateOrderDTO
	{
		[ShippedStatus]
		public string? OrderStatus { get; set; }
	}
}
