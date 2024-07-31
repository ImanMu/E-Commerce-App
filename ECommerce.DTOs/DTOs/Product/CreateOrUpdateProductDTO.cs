using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs.DTOs.Product
{
	public class CreateOrUpdateProductDTO
	{
		//public int ProductId { get; set; }
		[MinLength(3, ErrorMessage = "Length > 4")]
		public string ProductName { get; set; }
		[MaxLength(200)]
		public string Description { get; set; }
		[Range(0,double.MaxValue)]
		public decimal Price { get; set; }
		public int CategoryId { get; set; }
	}
}
