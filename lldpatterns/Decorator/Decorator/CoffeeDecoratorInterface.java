package Decorator;
public abstract class CoffeeDecoratorInterface implements CoffeComponentInterface
{
	protected CoffeComponentInterface Coffee;
	public CoffeeDecoratorInterface(CoffeComponentInterface Coffee)
	{
		this.Coffee = Coffee;
	}
	public void contents() {
		System.out.println("Coffee has decorated with");
		
	}
}