using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contract_Employee_Payments.Models
{
    public class TimeRecord
    {
        public int Id { get; set; }


        public int ProjectId { get; set; }

        public int ContractEmployeeId { get; set; }

        public ContractEmployee ContractEmployee { get; set; }

        public Project Project { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [NotMapped]
        public decimal Payment
        {
            get
            {

                return this.ContractEmployee.HourlyRate * (EndTime - StartTime).Hours;

            }
        }


        [NotMapped]
        public int HoursWorked
        {
            get
            {
                return (EndTime - StartTime).Hours;

            }
        }
    }
}
