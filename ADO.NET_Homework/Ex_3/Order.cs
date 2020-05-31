using System;

namespace Ex_3
{
    public class Order
    {
        public Order(string id, DateTime date, string custID)
        {
            OrderID = id;
            OrderDate = date;
            CustomerID = custID;
        }
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }

        public string CustomerID { get; set; }
        public override string ToString()
        {
            return $"OrderID {OrderID}, ORDER DATE {OrderDate}, {CustomerID}";
        }
    }
}