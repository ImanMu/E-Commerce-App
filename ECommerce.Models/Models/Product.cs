using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		[StringLength(50)]
		public string? ProductName { get; set; }
		[StringLength(200)]
		public string? Description { get; set; }
		[Column(TypeName = "money")]
		public decimal? Price { get; set; }
		public int? QuantityAvailable { get; set; }	
		public virtual Category? Category { get; set; }
		[ForeignKey("CategoryId")]
		public int CategoryId { get; set; }
		public virtual List<OrderProduct>? OrderProduct { get; set; }
	}
}
