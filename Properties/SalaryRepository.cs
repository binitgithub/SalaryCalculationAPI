using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaryCalculationAPI.Data;
using SalaryCalculationAPI.Models;

namespace SalaryCalculationAPI.Properties
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly EmpSalaryDbContext empSalaryDbContext;

        public SalaryRepository(EmpSalaryDbContext empSalaryDbContext)
        {
            this.empSalaryDbContext = empSalaryDbContext;
        }
        public async Task<SalaryModel> CreateSalaryAsync(SalaryModel salaryModel, decimal basic, decimal allowances, decimal deductions, decimal taxPercentage)
        {
            await empSalaryDbContext.SalaryModels.AddAsync(salaryModel);
            await empSalaryDbContext.SaveChangesAsync();
            decimal grossSalary = basic + allowances;
            decimal taxAmount = grossSalary * (taxPercentage / 100);
            decimal netSalary = grossSalary - (taxAmount + deductions);
            return salaryModel;
        }


        public async Task<SalaryModel> DeleteSalaryAsync(int id)
        {
            var DeleteSalary = await empSalaryDbContext.SalaryModels.FirstOrDefaultAsync(x => x.SalaryId == id);
            if (DeleteSalary == null)
            {
                return null;
            }
            empSalaryDbContext.SalaryModels.Remove(DeleteSalary);
            await empSalaryDbContext.SaveChangesAsync();
            return DeleteSalary;
        }

        public async Task<List<SalaryModel>> GetAllSalaryAsync()
        {
            return await empSalaryDbContext.SalaryModels.ToListAsync();
        }

        public async Task<SalaryModel> GetByIdSalaryAsync(int id)
        {
            return await empSalaryDbContext.SalaryModels.FirstOrDefaultAsync(x => x.SalaryId == id);
        }

        public async Task<SalaryModel> UpdateSalaryAsync(int id, SalaryModel salaryModel)
        {
            var updateeSalary = await empSalaryDbContext.SalaryModels.FirstOrDefaultAsync(x => x.SalaryId == id);
            if (updateeSalary == null)
            {
                return null;
            }

            updateeSalary.BasicSalary = salaryModel.BasicSalary;
            updateeSalary.Allowances = salaryModel.Allowances;
            updateeSalary.Deductions = salaryModel.Deductions;
            updateeSalary.TaxPercentage = salaryModel.TaxPercentage;

            await empSalaryDbContext.SaveChangesAsync();
            return updateeSalary;
        }
    }
}