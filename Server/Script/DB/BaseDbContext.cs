﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Server.Script.DB
{
    public class BaseDbContext : DbContext
    {
        private readonly string _connectionString;

        public BaseDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@_connectionString);
        }

        public DbSet<Student> Student { get; set; }
    }
}

public class Student
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}

