package org.example.models;

public class Car {
    private String model;
    private int year;
    private String licensePlate;
    private double rentPerDay;
    private Status isAvailable;
    private int bookedDays;

    public Car(String model, int year, String licensePlate, double rentPerDay, Status isAvailable, int bookedDays) {
        this.model = model;
        this.year = year;
        this.licensePlate = licensePlate;
        this.rentPerDay = rentPerDay;
        this.isAvailable = isAvailable;
        this.bookedDays = bookedDays;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public String getLicensePlate() {
        return licensePlate;
    }

    public void setLicensePlate(String licensePlate) {
        this.licensePlate = licensePlate;
    }

    public double getRentPerDay() {
        return rentPerDay;
    }

    public void setRentPerDay(double rentPerDay) {
        this.rentPerDay = rentPerDay;
    }

    public Status getIsAvailable() {
        return isAvailable;
    }

    public void setIsAvailable(Status isAvailable) {
        this.isAvailable = isAvailable;
    }

    public int getBookedDays()
    {
        return bookedDays;
    }

    public void setBookedDays(int bookedDays)
    {
        this.bookedDays = bookedDays;
    }
}
