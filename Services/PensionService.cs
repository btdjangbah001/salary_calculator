using System;
using challenge.IServices;
using challenge.Utils;

namespace challenge.Services
{
	public class PensionService : IPensionService
	{
		private static readonly decimal _tier1Employee = 0.0m;
		private static readonly decimal _tier2Employee = 0.055m;
        private static readonly decimal _tier3Employee = 0.05m;
        private static readonly decimal _tier1Employer = 0.13m;
        private static readonly decimal _tier2Employer = 0.0m;
        private static readonly decimal _tier3Employer = 0.05m;

		private readonly decimal[] _employeeDeductions = { _tier1Employee,  _tier2Employee, _tier3Employee };
		private readonly decimal[] _employerDeductions = { _tier1Employer, _tier2Employer, _tier3Employer };
        public decimal AmountBeforeEmployeePensionContribution(decimal salary)
		{
			decimal beforePension = salary;

			foreach (decimal deduc in _employeeDeductions)
			{
				beforePension = Utilities.CalculateAmountBeforeDeduction(beforePension, deduc);
			}

			return beforePension;
		}

        public decimal AmountBeforeEmployerEmployerPension(decimal salary)
		{
            decimal beforePension = salary;

            foreach (decimal deduc in _employeeDeductions)
            {
                beforePension = Utilities.CalculateAmountBeforeDeduction(beforePension, deduc);
            }

            return beforePension - salary;
        }
    }
}

