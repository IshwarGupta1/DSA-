package StrategyPattern.Strategies;

import StrategyPattern.Pay;

public class CreditCardPay implements Pay {

	@Override
	public void payment(int amount) {
		System.out.print("Credit Card Payment -- "+amount);

	}

}
