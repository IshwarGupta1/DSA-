package Decorator;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		CoffeComponentInterface coffee1 = new CoffeeComponent();
		CoffeComponentInterface coffee2 = new CoffeeComponent();
		coffee1 = new CoffeeDecoratorA(coffee1);
		coffee2 = new CoffeeDecoratorA(coffee2);
		coffee2 = new CoffeeDecoratorB(coffee2);
		coffee1.contents();
		coffee2.contents();
	}

}
