﻿using System;
namespace challenge.IServices
{
	public interface IPensionService
	{
		decimal AmountBeforeEmployeePensionContribution(decimal salary);
		decimal AmountBeforeEmployerPensionAmount(decimal salary);
	}
}

