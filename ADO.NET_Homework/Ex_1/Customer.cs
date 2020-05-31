namespace Ex_1
{
    public class Customer
    {
        public Customer(string id, string name)
        {
            CustomerID = id;
            CustomerName = name;
        }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }

        public override string ToString()
        {
            return $"CustomerID {CustomerID}, CUSTOMER NAME {CustomerName}";
        }
    }
}