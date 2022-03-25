
using MLShop.Database;

namespace MLShop.Services
{
    public class OrderService : IHostedService, IDisposable
    {
        private Timer _timer = null!;
        private readonly IOrdersDatabase _ordersDatabase;

        public OrderService(IOrdersDatabase ordersDatabase)
        {
            _ordersDatabase = ordersDatabase;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateOrder, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private void UpdateOrder(object? state)
        {
            _ordersDatabase.resetOrders();
            _ordersDatabase.updateStatus();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
