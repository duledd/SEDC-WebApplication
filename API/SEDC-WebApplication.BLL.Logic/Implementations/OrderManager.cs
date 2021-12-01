using AutoMapper;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models;
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
        private readonly IProductDAL _productDAL;
        private readonly IMapper _mapper;
        public OrderManager(IOrderDAL orderDAL, IProductDAL productDAL, IMapper mapper)
        {
            _orderDAL = orderDAL;
            _productDAL = productDAL;
            _mapper = mapper;
        }
        public OrderDTO Add(OrderDTO orderDto)
        {
            Order order = new Order();
            order.TotalAmount = 0;
            order.Number = CreateOrderNumber();
            order.Status = 1;
            order.OrderItems = new List<OrderItem>();
            DateTime date = DateTime.Now;
            order.Date = date;

            foreach (OrderItemDTO orderItemDto in orderDto.OrderItems)
            {
                Product product = _productDAL.GetById(orderItemDto.ProductId);
                order.TotalAmount += product.UnitPrice * orderItemDto.Quantity;

                OrderItem orderItem = new OrderItem();
                orderItem.ProductId = product.Id;
                orderItem.Quantity = orderItemDto.Quantity;

                order.OrderItems.Add(orderItem);
            }
            _orderDAL.Save(order);

            return orderDto;
        }
        private string CreateOrderNumber()
        {
            return "N";
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
        public OrderDTO Update(int id, OrderDTO order)
        {
            Order orderEntity = _mapper.Map<Order>(order);
            _orderDAL.Update(orderEntity);
            order = _mapper.Map<OrderDTO>(orderEntity);
            return order;
        }

        IEnumerable<Order> IOrderManager.GetOrdersByCustomerId(int id)
        {
            return _mapper.Map<List<Order>>(_orderDAL.GetByCustomerId(0, 50, id));
            //try
            //{
            //    List<Order> order = _orderDAL.GetByCustomerId(0, 50, id);
            //    if (order == null)
            //    {
            //        throw new Exception($"Customer with id {id} not found.");
            //    }
            //    List<OrderDTO> orderDTO = _mapper.Map<List<OrderDTO>>(_orderDAL.GetByCustomerId(0, 50, id));
            //    //customerDTO.Orders = _orderDAL.GetByCustomerId((int)customer.CustomerId);
            //    return orderDTO;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
