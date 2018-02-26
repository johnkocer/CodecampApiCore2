using BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
   public class EmployeeDataContext:DbContext
   {
      public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options) { }

      public DbSet<Employee> Employee { get; set; }
   }
}
