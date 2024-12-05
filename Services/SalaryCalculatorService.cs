using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCalculationAPI.Services
{
    public class SalaryCalculatorService
    {
        public decimal CalculateNetSalaryAsync (decimal basic, decimal allowances, decimal deductions, decimal taxPercentage)
        {
            decimal grossSalary = basic + allowances;
            decimal taxAmount = grossSalary * (taxPercentage / 100);
            decimal netSalary = grossSalary - (taxAmount + deductions);
            return netSalary;
        }
    }
}