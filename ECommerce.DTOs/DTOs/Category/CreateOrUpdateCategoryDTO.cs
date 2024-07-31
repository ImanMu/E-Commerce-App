using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTOs.DTOs.Category
{
	public class CreateOrUpdateCategoryDTO
	{
		//public int CategoryId { get; set; }
		[MinLength(3, ErrorMessage = "Length > 4")]
		public string CategoryName { get; set; }
	}
}
