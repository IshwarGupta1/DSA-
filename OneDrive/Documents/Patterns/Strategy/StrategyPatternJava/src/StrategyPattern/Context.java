package StrategyPattern;

public class Context {
	 private Pay _pay;
	 public Context(Pay pay)
	 {
		 _pay = pay;
	 }
	 public void payment(int amount)
	 {
		 _pay.payment(amount);
	 }
}
