using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ComtuperModel> ComtuperModels { get; set; }
        public DbSet<ComputerManufactyrer> ComputerManufactyrers { get; set; }
        public DbSet<ComputerModelTag> ComputerModelTags { get; set; }
        public int SaveChanges();
    }
}
