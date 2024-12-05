using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalaryCalculationAPI.Models;

namespace SalaryCalculationAPI.Properties
{
    public interface ISalaryRepository
    {
        Task<List<SalaryModel>> GetAllSalaryAsync();
        Task<SalaryModel> GetByIdSalaryAsync(int id);
        Task<SalaryModel> CreateSalaryAsync(SalaryModel salaryModel, decimal basic, decimal allowances, decimal deductions, decimal taxPercentage);
        Task<SalaryModel> UpdateSalaryAsync(int id, SalaryModel salaryModel);
        Task<SalaryModel> DeleteSalaryAsync(int id);
    }
}