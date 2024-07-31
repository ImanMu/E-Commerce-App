using ECommerce.DTOs.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public interface IOrderService
    {
        List<GetAllOrdersDTO> GetAll();
        bool Create(CreateOrderDTO o);
		bool Update(int id, UpdateOrderDTO o);
		bool Delete(int Id);
	}
}
