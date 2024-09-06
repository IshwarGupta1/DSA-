package Decorator;

public class CoffeeDecoratorA extends CoffeeDecoratorInterface {

	public CoffeeDecoratorA(CoffeComponentInterface Coffee) {
		super(Coffee);
		// TODO Auto-generated constructor stub
	}
	
	public void contents() {
		System.out.println(" with Sugar");
	}
}
