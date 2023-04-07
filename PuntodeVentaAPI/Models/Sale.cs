namespace PuntodeVentaAPI.Models
{
    public class Sale
    {
        public int Id{ get; set; }

        public string Date { get; set; } 

        public Inventory Inventory { get; set; } //One to Many 

        public int QuantitySold { get; set; } = 0;

        public bool Registered { get; set; } = false;

        
    }
}
