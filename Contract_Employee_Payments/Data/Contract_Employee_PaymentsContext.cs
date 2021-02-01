using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contract_Employee_Payments.Models;

namespace Contract_Employee_Payments.Data
{
    public class Contract_Employee_PaymentsContext : DbContext
    {
        public Contract_Employee_PaymentsContext (DbContextOptions<Contract_Employee_PaymentsContext> options)
            : base(options)
        {
        }

        public DbSet<Contract_Employee_Payments.Models.ContractEmployee> ContractEmployee { get; set; }

        public DbSet<Contract_Employee_Payments.Models.Project> Project { get; set; }

        public DbSet<Contract_Employee_Payments.Models.TimeRecord> TimeRecord { get; set; }
    }
}
