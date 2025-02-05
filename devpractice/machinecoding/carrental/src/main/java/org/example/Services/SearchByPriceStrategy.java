package org.example.Services;

import org.example.models.Car;

import java.util.ArrayList;
import java.util.List;

public class SearchByPriceStrategy implements ISearchStrategy{
    @Override
    public List<Car> search(List<Car> cars, Object searchType) {
        double price = (double) searchType;
        List<Car> resultCars = new ArrayList<>();
        for(int i=0; i<cars.size(); i++)
        {
            if(cars.get(i).getRentPerDay() <= price)
                resultCars.add(cars.get(i));
        }
        return resultCars;
    }
}
