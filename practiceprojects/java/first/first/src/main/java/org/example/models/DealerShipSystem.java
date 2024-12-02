package org.example.models;

import java.util.ArrayList;
import java.util.List;

public class DealerShipSystem {
    List<Car> cars;
    public DealerShipSystem()
    {
        this.cars = new ArrayList<>();
    }

    public void ShowCars()
    {
        for(int i=0;i<cars.size();i++)
        {
            Car cari = cars.get(i);
            System.out.print(cari.getModel());
            System.out.print(cari.getFuel());
            System.out.println(cari.getPrice());
        }
    }

    public void canPurchaseCar(Customer customer, Car car)
    {
        if(!cars.contains(car))
            System.out.println("Car not present");
        double price = car.getPrice();
        double amount = customer.budget;
        if(amount>=price)
            System.out.println("Car can be bought");
        else
            System.out.println("Car cannot be bought");
    }
}
