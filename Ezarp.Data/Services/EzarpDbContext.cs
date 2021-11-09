using Ezarp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ezarp.Data.Services
{
    public class EzarpDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}