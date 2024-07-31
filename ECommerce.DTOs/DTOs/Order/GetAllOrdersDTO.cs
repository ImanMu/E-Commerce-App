using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs.DTOs.Order
{
	public class GetAllOrdersDTO
	{
		public int OrderId { get; set; }
		public string? OrderStatus { get; set; }
		public DateTime CreatedDate { get; set; }

	}
}
