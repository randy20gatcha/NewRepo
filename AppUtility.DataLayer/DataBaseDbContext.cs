using AppUtility.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppUtility.DataLayer
{
    public class DataBaseDbContext :DbContext
    {
        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options)
            : base (options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
