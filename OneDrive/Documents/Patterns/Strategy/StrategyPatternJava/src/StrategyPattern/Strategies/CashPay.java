package StrategyPattern.Strategies;

import StrategyPattern.Pay;

public class CashPay implements Pay {

	@Override
	public void payment(int amount) {
		System.out.print("Cash Payment -- "+amount);

	}

}
