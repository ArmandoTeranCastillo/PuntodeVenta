namespace PuntodeVentaAPI.Models
{
    public class PartialClosure
    {
        public int Id { get; set; } 

        public string Date { get; set; } = string.Empty;

        public Product Product { get; set; } //One To Many

        public int QuantitySold { get; set; } = 0;

        public float TotalSale { get; set; } = 0;

        public bool Closed { get; set; } = false;


    }
}
