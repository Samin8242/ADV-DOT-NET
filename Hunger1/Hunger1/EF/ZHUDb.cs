using Hunger1.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hunger1.EF
{
    public class ZHUDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
    }
}