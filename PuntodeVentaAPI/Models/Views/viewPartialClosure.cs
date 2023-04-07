namespace PuntodeVentaAPI.Models.Views
{
    public class viewPartialClosure
    {
        public int Id { get; set; }

        public string Date { get; set; } = string.Empty;

        public int ProductId { get; set; } = 1;

        public int QuantitySold { get; set; } = 0;

        public float TotalSale { get; set; } = 0;

        public bool Closed { get; set; } = false;
    }
}
