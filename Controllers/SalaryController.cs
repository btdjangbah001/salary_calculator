using challenge.IServices;
using challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers;

[ApiController]
[Route("[controller]")]
public class salaryController : Controller
{
    private readonly ISalaryService _salaryService;
    private readonly IPensionService _pensionService;
    public salaryController(ISalaryService salaryService, IPensionService pensionService)
    {
        _salaryService = salaryService;
        _pensionService = pensionService;
    }

    [HttpPost]
    public ActionResult<SalaryDetails> GetGrossSalary([FromBody] NetSalary salary)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("You are missing either salary or allowance");
        }

        decimal salaryBeforetax = _salaryService.CalculateSalaryAndAllowanceBeforeTax(salary.Salary + salary.Allowance);
        decimal salaryBeforeTaxAndEmployeePension = _pensionService.AmountBeforeEmployeePensionContribution(salaryBeforetax);
        decimal employeeAmount = _pensionService.AmountBeforeEmployerEmployerPension(salaryBeforeTaxAndEmployeePension);

        return Ok(new SalaryDetails
        {
            BasicSalary = Math.Round((double)salaryBeforeTaxAndEmployeePension, 2),
            TotalPAYETax = Math.Round((double)(salaryBeforetax - (salary.Salary + salary.Allowance)), 2),
            EmployeePensionContribution = Math.Round((double)(salaryBeforeTaxAndEmployeePension - salaryBeforetax), 2),
            EmployerPensionAmount = Math.Round((double)employeeAmount, 2)
        });
    }
}
