namespace Ex_2
{
    ////внутри должна быть информация о заказе: место, поставщик, покупатель.+Представление создаете в БД, через ADO.Net обращаетесь уже к созданному объекту
    public class Waybill
    {
        public Waybill(int id, string city, string ship, string customer)
        {
            ID = id;
            City = city;
            ShipName = ship;
            CustomerName = customer;
        }
        public int ID { get; set; }
        public string City { get; set; }
        public string ShipName { get; set; }
        public string CustomerName { get; set; }

        public override string ToString()
        {
            return $"Information order {ID}, {City}, {ShipName}, {CustomerName}";
        }
    }
}