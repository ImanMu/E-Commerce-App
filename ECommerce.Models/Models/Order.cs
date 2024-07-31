using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
	public class Order

	{
		public Order()
		{
			CreatedDate = DateTime.Now;
			OrderStatus = "NotShipped";
		}
		[Key]
		public int OrderId { get; set; }
		public DateTime? CreatedDate { get; set; }
		[Column(TypeName = "money")]
		public decimal? TotalPrice { get; set; }
		public string? OrderStatus { get; set; }	
		[ForeignKey("CustomerId")]
		public int? CustomerId { get; set; }	
		public virtual Customer? Customer { get; set; }
		public virtual List<OrderProduct>? OrderProduct { get; set; }
	}
}
