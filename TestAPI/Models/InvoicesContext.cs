using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models;

public partial class InvoicesContext : DbContext
{
    public InvoicesContext(DbContextOptions<InvoicesContext> options) : base(options)
    {

    }

    public DbSet<BuildPlace> BuildPlaces { get; set; }

    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<Kit> Kits { get; set; }

    public  DbSet<Part> Parts { get; set; }
}
