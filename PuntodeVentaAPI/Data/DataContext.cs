
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PuntodeVentaAPI.Models;
using PuntodeVentaAPI.Models.Views;

namespace PuntodeVentaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<PartialClosure> PartialClosure { get; set; }

        public DbSet<TotalClosure> TotalClosure { get; set; }

        public DbSet<User> users { get; set; }

        //Vistas
        public DbSet<viewInventory> viewInventory { get; set; }

        public DbSet<viewPartialClosure> viewPartialClosure { get; set; }

        public DbSet<viewTotalClosure> viewTotalClosure { get; set; }

       
    }
}
