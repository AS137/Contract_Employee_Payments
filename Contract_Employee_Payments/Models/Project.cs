using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contract_Employee_Payments.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int EstimatedHours { get; set; }

        [NotMapped]
        public string ProjectCode
        {
            get
            {

                return ProjectName + "_" + ProjectId;

            }
        }
    }
}
