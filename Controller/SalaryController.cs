using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculationAPI.Models;
using SalaryCalculationAPI.Properties;
using SalaryCalculationAPI.Services;

namespace SalaryCalculationAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryRepository salaryRepository;
        private readonly SalaryCalculatorService salaryCalculatorService;

        public SalaryController(ISalaryRepository salaryRepository, SalaryCalculatorService salaryCalculatorService)
        {
            this.salaryRepository = salaryRepository;
            this.salaryCalculatorService = salaryCalculatorService;
        }

    //Get All Salary
    [HttpGet]
    public async Task<IActionResult> GetAllSalary()
    {
        var GetAllSlaryModel = await salaryRepository.GetAllSalaryAsync();
        
        if (GetAllSlaryModel == null)
        {
            return NotFound();
        }
        return Ok();
    }

    //Get Salary By id
    [HttpGet ("{id:int}")]
    public async Task<IActionResult> SlaryGetById([FromRoute] int id)
    {
        var getSalaryByIdModel = await salaryRepository.GetByIdSalaryAsync(id);
        if (getSalaryByIdModel == null)
        {
            return null;
        }
        return Ok();
    }

    //Create Salary
    [HttpPost]
    public async Task<IActionResult> CreateSalary([FromBody] SalaryModel salaryModel, decimal basic, decimal allowances, decimal deductions, decimal taxPercentage )
    {
        var CreateSalaryModel = await salaryRepository.CreateSalaryAsync(salaryModel, basic, allowances, deductions, taxPercentage);
        return CreatedAtAction(nameof(SlaryGetById), new {id = CreateSalaryModel.SalaryId }, CreateSalaryModel);
    }

    //
    }
}