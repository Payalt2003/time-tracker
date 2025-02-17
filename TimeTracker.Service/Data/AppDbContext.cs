﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Service.Entities;

namespace TimeTracker.Service.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }

        public DbSet<JobType> JobTypes { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
