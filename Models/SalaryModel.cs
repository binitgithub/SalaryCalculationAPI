using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalaryCalculationAPI.Models
{
    public class SalaryModel
    {
        public int SalaryId { get; set; }
        [Required]
        [Precision(18, 4)] // Specify precision and scale
        public decimal BasicSalary { get; set; }
        [Required]
        [Precision(18, 4)] // Specify precision and scale
        public decimal Allowances { get; set; }
        [Required]
        [Precision(18, 4)] // Specify precision and scale
        public decimal Deductions { get; set; }
        [Required]
        [Precision(18, 4)] // Specify precision and scale
        public decimal TaxPercentage { get; set; } // Optional for tax calculation
    }
}