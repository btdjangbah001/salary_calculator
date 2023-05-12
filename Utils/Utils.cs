using System;
namespace challenge.Utils
{
	public static class Utilities
	{
        public static decimal CalculateAmountBeforeDeduction(decimal salary, decimal deductionRate)
        {
            return salary / (1 - deductionRate);
        }
    }
}
