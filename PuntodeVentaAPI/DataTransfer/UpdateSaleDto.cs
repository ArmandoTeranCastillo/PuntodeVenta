namespace PuntodeVentaAPI.DataTransfer
{
    public class UpdateSaleDto
    {
        public int Id { get; set; }

        public int InventoryId { get; set; } = 0;

        public int QuantitySold { get; set; } = 1;

        public bool Registered { get; set; } = false;

        public string Date { get; set; } = string.Empty;
    }
}
