package StrategyPattern;

import StrategyPattern.Strategies.*;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int amount = 1000;
		var context1 = new Context(new UPIPay());
		context1.payment(amount);
		var context2 = new Context(new CashPay());
		context2.payment(amount);
		var context3 = new Context(new CreditCardPay());
		context3.payment(amount);

	}

}
