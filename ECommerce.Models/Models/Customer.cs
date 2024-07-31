using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }
		[StringLength(50)]
		public string? CustomerName { get; set; }
		[StringLength(100)]
		public string? Address { get; set; }
		[StringLength(50)]
		public string? PhoneNumber { get; set; }
		[StringLength(50)]
		public string? Email { get; set; }	
		public virtual List<Order>? Orders { get; set; }
	}
}
