using AutoMapper;
using ECommerce.DTOs.DTOs.Order;
using ECommerce.Models;
using ECommerce.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ECommerce.Services
{
    public class OrderService : IOrderService
	{
        IOrderRepository OrderRepository;
        IMapper Mapper;
        public OrderService(IOrderRepository _OrderRepository, IMapper _mapper)
        {
			OrderRepository = _OrderRepository;
            Mapper= _mapper;
        }
        public List<GetAllOrdersDTO> GetAll()
        {
            var Orders = OrderRepository.GetAll().ToList();
            var usersDTO = Mapper.Map<List<GetAllOrdersDTO>>(Orders);
            return usersDTO;
        }
        public bool Create(CreateOrderDTO o)
        {
            if (!o.Products.Any())
            {
				return false;
			}
            else
            {
                Order Order = Mapper.Map<Order>(o);
                OrderRepository.Create(Order);
              
                return true;
            }
        }
        public bool Update(int Id, UpdateOrderDTO o)
        {
            var UpdatedOrder = OrderRepository.GetAll().Where(o => o.OrderId == Id).FirstOrDefault();
            if (UpdatedOrder == null)
            {
                return false;
            }
            else
            {
                Mapper.Map(o, UpdatedOrder);
				OrderRepository.Update(UpdatedOrder);
                return true;
            }
        }
        public bool Delete(int Id)
        {
            var DeletedOrder = OrderRepository.GetAll().Where(o => o.OrderId == Id).FirstOrDefault();
            if (DeletedOrder == null)
            {
                return false;
            }
            else
				OrderRepository.Delete(DeletedOrder);
                return true;
        }
    }
}
