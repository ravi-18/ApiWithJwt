namespace ApiWithJwt.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; } 
        public string OrderName { get; set; }
        public double OrderAmount { get; set; }
        public int OrderQuatity { get; set; }
    }
}
