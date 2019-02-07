using CzSoft.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CzSoft.Data
{
    public class CzSoftDbContext : DbContext
    {
        public CzSoftDbContext(DbContextOptions<CzSoftDbContext> options) : base(options) 
        {

        }
        public DbSet<Project> Projects { get; set; }
    }
}
