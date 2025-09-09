using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Domain.Entities;

namespace SimpleECommerce.Infrastructure.Contexts;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cancellation> Cancellations { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FaqItem> FaqItems { get; set; }
    public DbSet<FaqItemFile> FaqItemFiles { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Refund> Refunds { get; set; }
    public DbSet<Product> Products { get; set; }
    //identity Number , snapshot , ticket , flow , 
}