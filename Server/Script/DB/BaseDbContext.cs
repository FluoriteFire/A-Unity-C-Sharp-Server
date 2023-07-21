using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Script.DB
{
    public class BaseDbContext : DbContext
    {
        //"server=localhost;port=3306;database=test;uid=root;pwd=123456;CharSet=utf8"
        private readonly string _connectionString;

        public BaseDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        public DbSet<Student> Student { get; set; }
    }
}

public class Student
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }

    public string Number { get; set; }

    public string Address { get; set; }
}

