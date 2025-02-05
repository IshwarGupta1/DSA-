package org.example.Services;

import org.example.models.Car;

import java.util.ArrayList;
import java.util.List;

public class SearchByModelStrategy implements ISearchStrategy{
    @Override
    public List<Car> search(List<Car> cars, Object searchType) {
        String model = (String)searchType;
        List<Car> resultCars = new ArrayList<>();
        for(int i=0; i<cars.size(); i++)
        {
            if(cars.get(i).getModel() == model)
                resultCars.add(cars.get(i));
        }
        return resultCars;
    }
}
