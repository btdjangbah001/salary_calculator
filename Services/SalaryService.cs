using System;
using challenge.IServices;
using challenge.Utils;

namespace challenge.Services
{

    public class Tax
    {
        public decimal Limit { get; set; }
        public decimal TaxRate { get; set; }

        // lazy evaluating what the maximum after tax is, good for performance, but a bit bsd for readability becuause of C#
        private bool _maximumIsComputed;
        private decimal _computedMaximumAfterTax;

        public decimal MaximumAmountAfterTax
        {
            get
            {
                if (!_maximumIsComputed)
                {
                    _computedMaximumAfterTax = _computeMaximumAmountAfterTax();
                    _maximumIsComputed = true;
                }
                return _computedMaximumAfterTax;
            }
        }

        private decimal _computeMaximumAmountAfterTax()
        {
            return Limit * (1 - TaxRate);
        }
    }

    public class SalaryService : ISalaryService 
    {
        private Tax stageOne = new Tax { Limit = 319.0m, TaxRate = 0.0m }; 
        private Tax stageTwo = new Tax { Limit = 419.0m, TaxRate = 0.05m }; 
        private Tax stageThree = new Tax { Limit = 539.0m, TaxRate = 0.10m }; 
        private Tax stageFour = new Tax { Limit = 3_539.0m, TaxRate = 0.175m }; 
        private Tax stageFive = new Tax { Limit = 20_000.0m, TaxRate = 0.25m }; 
        private Tax stageSix = new Tax { Limit = decimal.MaxValue, TaxRate = 0.3m }; 
            
        public decimal CalculateSalaryAndAllowanceBeforeTax(decimal netSalary)
        {
            if (netSalary < stageOne.MaximumAmountAfterTax)
            {
                Console.WriteLine(stageOne.MaximumAmountAfterTax);

                return netSalary; // since tax rate is 0.0 there is no need to call the method to calculate
            }
            if (netSalary < stageTwo.MaximumAmountAfterTax)
            {
                Console.WriteLine(stageTwo.MaximumAmountAfterTax);

                return Utilities.CalculateAmountBeforeDeduction(netSalary, stageTwo.TaxRate);
            }
            if (netSalary < stageThree.MaximumAmountAfterTax)
            {
                Console.WriteLine(stageThree.MaximumAmountAfterTax);

                return Utilities.CalculateAmountBeforeDeduction(netSalary, stageThree.TaxRate);
            }
            if (netSalary < stageFour.MaximumAmountAfterTax)
            {
                Console.WriteLine(stageFour.MaximumAmountAfterTax);

                return Utilities.CalculateAmountBeforeDeduction(netSalary, stageFour.TaxRate);
            }
            if (netSalary < stageFive.MaximumAmountAfterTax)
            {
                Console.WriteLine(stageFive.MaximumAmountAfterTax);

                return Utilities.CalculateAmountBeforeDeduction(netSalary, stageFive.TaxRate);
            }
            if (netSalary < stageSix.MaximumAmountAfterTax)
            {
                Console.WriteLine(stageSix.MaximumAmountAfterTax);

                return Utilities.CalculateAmountBeforeDeduction(netSalary, stageSix.TaxRate);
            }
            return 0.0m; // control will never reach here so it's safe. I just don't like using if-else if-else statements
       }
    }
}
