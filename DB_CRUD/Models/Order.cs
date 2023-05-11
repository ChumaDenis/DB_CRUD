namespace DB_CRUD.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderCost { get; set; }

        public string ItemsDescription { get; set; }

        public string ShippingAddress { get; set; }
    }
}
