using System;

namespace challenge.IServices {
    
    public interface ISalaryService {
        decimal CalculateSalaryAndAllowanceBeforeTax(decimal netSalary);
    }
}
