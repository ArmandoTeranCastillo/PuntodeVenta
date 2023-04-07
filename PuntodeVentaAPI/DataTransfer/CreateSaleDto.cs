namespace PuntodeVentaAPI.DataTransfer
{
    public class CreateSaleDto
    {
        public int InventoryId { get; set; } = 0;

        public int QuantitySold { get; set; } = 0;

        public bool Registered { get; set; } = false;

        public string Date { get; set; } = string.Empty;
    }
}
