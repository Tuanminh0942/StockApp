using StockAppApi.Models;
using StockAppApi.ViewModel;

namespace StockAppApi.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(OrderViewModel order);
    }
}
