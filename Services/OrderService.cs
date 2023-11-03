using StockAppApi.Models;
using StockAppApi.Repositories;
using StockAppApi.ViewModel;

namespace StockAppApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Order>> GetOrderHistories()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> PlaceOrder(OrderViewModel orderViewModel)
        {
            if(orderViewModel.Quantity == 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }
            return await _orderRepository.CreateOrder(orderViewModel);
        }
    }
}
