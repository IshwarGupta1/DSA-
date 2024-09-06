package Decorator;

import java.io.*;

public class CoffeeComponent implements CoffeComponentInterface{

	@Override
	public void contents() {
		System.out.println("Coffee has coffee beans and milk");
		
	}
	
}
