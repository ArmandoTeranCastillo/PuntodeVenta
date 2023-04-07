using NuGet.Versioning;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntodeVentaAPI.Models.Views
{
    public class viewInventory
    {
        public int Id { get; set; } 

        public Product Product { get; set; } // Relationship

        public int Quantity { get; set; } = 1;

        public int RealQuantity { get; set; } = 1;

        [NotMapped]
        public bool IfQuantityIsZero => Quantity <= 0;


    }
}
