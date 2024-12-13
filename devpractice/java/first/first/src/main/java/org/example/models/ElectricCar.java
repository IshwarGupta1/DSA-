package org.example.models;

public class ElectricCar extends Car{

    public ElectricCar(double price, String model, String fuel) {
        super(price, model, fuel);
    }

    @Override
    public double getPrice() {
        return super.getPrice();
    }

    @Override
    public void setPrice(double price) {
        super.setPrice(price);
    }

    @Override
    public String getModel() {
        return "EV Vehicle";
    }

    @Override
    public String getFuel() {
        return "only Battery";
    }
}
