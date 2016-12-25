using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyRoughSite1.Models
{
    public class MasseurContext : DbContext
    {
        public DbSet<Masseur> Masseurs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<VacantRegister> VacantRegisters { get; set; }
    }
}