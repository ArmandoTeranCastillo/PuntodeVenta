using PuntodeVentaAPI.Models;

namespace PuntodeVentaAPI.DataTransfer
{
    public class CreateTotalClosureDto
    {
        public int Id { get; set; }

        public string Date { get; set; } = string.Empty;

        public int ProductId { get; set; } = 1;

        public virtual Product Product { get; set; }

        public int QuantitySold { get; set; } = 1;

        public float TotalSale { get; set; } = 1;
    }
}
