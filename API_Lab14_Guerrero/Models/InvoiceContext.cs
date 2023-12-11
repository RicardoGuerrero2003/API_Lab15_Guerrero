using Microsoft.EntityFrameworkCore;

namespace API_Lab14_Guerrero.Models
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details  { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
     
    }
}
