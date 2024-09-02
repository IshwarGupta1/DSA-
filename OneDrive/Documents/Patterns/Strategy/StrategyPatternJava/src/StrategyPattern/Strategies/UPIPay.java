package StrategyPattern.Strategies;

import StrategyPattern.Pay;

public class UPIPay implements Pay {

	@Override
	public void payment(int amount) {
		System.out.print("UPI Payment -- "+amount);

	}

}
