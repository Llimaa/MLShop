namespace MLShop.Database
{
    public class OrdersDatabase : IOrdersDatabase
    {
        private static IList<Order> _orders = new List<Order>();
        public OrdersDatabase()
        {
            for (int i = 1; i <= 10; i++)
            {
                _orders.Add(new Order(i + 1, i + 2, 10 * i));
            }
        }

        public void updateStatus()
        {
            for (int i = 0; i < _orders.Count; i++)
            {
                _orders[i].Update();
            }
        }

        public void resetOrders()
        {
            for (int i = 0; i < _orders.Count; i++)
            {
                _orders[i].Reset();
            }
        }
    }

    public class Order
    {
        public Order(int id, int productId, double price)
        {
            Id = id;
            ProductId = productId;
            Price = price;
            Status = OrderStatus.Created;
        }

        public void Update()
        {
            Status = OrderStatus.InAnalyze;
        }

        public void Reset()
        {
            Status = OrderStatus.Created;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        Created = 1,
        InAnalyze = 2,
        Finish = 3
    }

    public interface IOrdersDatabase
    {
        void updateStatus();

        void resetOrders();
    }
}
