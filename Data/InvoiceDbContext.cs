using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
    public class InvoiceDbContext :DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<InvoiceAssignments> InvoiceAssignments { get; set; }

    }
}
