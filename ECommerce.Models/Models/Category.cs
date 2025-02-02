﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		[StringLength(50)]
		public string? CategoryName { get; set; }
		[StringLength(200)]
		public string? Description { get; set; }
		public virtual List<Product>? Products { get; set;} 
	}
}
