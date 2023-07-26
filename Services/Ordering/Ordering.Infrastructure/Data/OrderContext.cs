using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Core.Common;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }



    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "aleksandar"; //TODO: this will be replaced Identity Server
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "aadf"; //TODO: this will be replaced Identity Server
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}