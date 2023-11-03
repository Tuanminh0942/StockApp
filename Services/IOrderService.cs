using StockAppApi.Models;
using StockAppApi.ViewModel;

namespace StockAppApi.Services
{
    public interface IOrderService
    {
        Task<Order> PlaceOrder(OrderViewModel orderViewModel);
        Task<List<Order>> GetOrderHistories();
    }
}
