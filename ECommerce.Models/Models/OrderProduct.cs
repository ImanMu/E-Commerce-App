using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
	public class OrderProduct
	{ 
		public int ProductId { get; set; }
		public virtual Product? Product { get; set; }
		public int OrderId { get; set; }
		public virtual Order? order { get; set; }
		[Range(1, int.MaxValue)]
		public int? Quantity { get; set; }
	}
}
