package Decorator;

public class CoffeeDecoratorB extends CoffeeDecoratorInterface {

	public CoffeeDecoratorB(CoffeComponentInterface Coffee) {
		super(Coffee);
		// TODO Auto-generated constructor stub
	}
	
	public void contents() {
		System.out.println(" with Cream");
	}
}
