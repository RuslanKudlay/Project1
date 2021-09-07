﻿using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {

        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ComtuperModel> ComtuperModels { get; set; }
        public DbSet<ComputerManufactyrer> ComputerManufactyrers { get; set; }
        public DbSet<ComputerModelTag> ComputerModelTags { get; set; }
    }
}
