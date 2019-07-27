using CashflowTracker.Data.Configurations;
using CashflowTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Data
{
    public class CashflowTrackerContext : DbContext
    {
        public CashflowTrackerContext(DbContextOptions<CashflowTrackerContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<CostItem> CostItems { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventUserConfiguration).Assembly);
        }
    }
}
