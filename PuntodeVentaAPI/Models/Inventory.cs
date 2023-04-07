namespace PuntodeVentaAPI.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; } = 0;
    }
}
