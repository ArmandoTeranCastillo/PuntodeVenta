namespace PuntodeVentaAPI.Models.Views
{
    public class viewSale
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public int ProductId { get; set; } = 1;

        public int QuantitySold { get; set; }

        public bool Registered { get; set; }

        public string Date { get; set; } = string.Empty;
    }

}
