using Sifat.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sifat.EF
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}