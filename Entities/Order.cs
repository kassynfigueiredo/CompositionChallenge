using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositionChallenge.Entities;
using CompositionChallenge.Entities.Enums;

namespace CompositionChallenge.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items = new List<OrderItem>();
        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double total = 0;
            foreach (OrderItem i in Items)
            {
                total += i.SubTotal();
            }
            return total;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order moment : {DateTime.Now}");
            sb.AppendLine($"Order status: {OrderStatus.Processing}");
            sb.AppendLine($"Client {Client.Name} - {Client.BirthDate} - {Client.Email}");
            sb.AppendLine("Order items: ");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"Total price: {Total().ToString()}");
            return sb.ToString();
        }
    }
}
