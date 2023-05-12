using System;
using System.ComponentModel.DataAnnotations;

namespace challenge.Models
{
    
    public class NetSalary {
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public decimal Allowance { get; set; }
    }

    public class SalaryDetails
    {
        public double GrossSalary { get; set; }
        public double BasicSalary { get; set; }
        public double TotalPAYETax { get; set; }
        public double EmployeePensionContribution { get; set; }
        public double EmployerPensionAmount { get; set; }
    }
}
