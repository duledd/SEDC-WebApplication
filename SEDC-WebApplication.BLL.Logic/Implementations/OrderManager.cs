using AutoMapper;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
using SEDC_WebApplicationDataBaseFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Implementations
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDAL _orderDAL;
        private readonly IMapper _mapper;
        public OrderManager(IOrderDAL orderDAL, IMapper mapper)
        {
            _orderDAL = orderDAL;
            _mapper = mapper;
        }
        public OrderDTO Add(OrderDTO order)
        {
            Order orderEntity = _mapper.Map<Order>(order);
            _orderDAL.Save(orderEntity);
            order = _mapper.Map<OrderDTO>(orderEntity);
            return order;
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            List<OrderDTO> orderDTO = _mapper.Map<List<OrderDTO>>(_orderDAL.GetAll(0, 50));
            return orderDTO;
        }

        public OrderDTO GetOrderById(int id)
        {
            try
            {
                Order order = _orderDAL.GetById(id);
                if (order == null)
                {
                    throw new Exception($"Customer with id {id} not found.");
                }
                OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);
                //customerDTO.Orders = _orderDAL.GetByCustomerId((int)customer.CustomerId);
                return orderDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
