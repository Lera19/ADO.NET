using System;

namespace Ex_1
{
    public class Order
    {
        public Order(string id, DateTime date)
        {
            OrderID = id;
            OrderDate = date;
        }
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public override string ToString()
        {
            return $"OrderID {OrderID}, ORDER DATE {OrderDate}";
        }
    }
}