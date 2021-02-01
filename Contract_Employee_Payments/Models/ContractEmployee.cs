using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contract_Employee_Payments.Models
{
    public class ContractEmployee
    {
        [Key]
        public int ContractEmployeeId { get; set; }

        public string Name { get; set; }

        public decimal HourlyRate { get; set; }
    }
}
