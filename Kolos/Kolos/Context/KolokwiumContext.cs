using Kolokwium.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Context;

public class KolokwiumContext : DbContext
{
    public KolokwiumContext()
    {
    }

    public KolokwiumContext(DbContextOptions<KolokwiumContext> options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pastry> Pastries { get; set; }
    public DbSet<OrderPastry> OrderPastries { get; set; }
}