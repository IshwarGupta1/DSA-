package org.example.models;

public class Car {
    double price;
    String model;
    String fuel;

    public Car(double price, String model, String fuel) {
        this.price = price;
        this.model = model;
        this.fuel = fuel;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public String getFuel() {
        return fuel;
    }

    public void setFuel(String fuel) {
        this.fuel = fuel;
    }
}
