package org.example.Services;

import org.example.models.*;


import java.util.ArrayList;
import java.util.List;

public class SearchByAvailability implements ISearchStrategy{

    @Override
    public List<Car> search(List<Car> cars, Object searchType) {
        Status status = (Status)searchType;
        List<Car> resultCars = new ArrayList<>();
        for(int i=0; i<cars.size(); i++)
        {
            if(cars.get(i).getIsAvailable() == status)
                resultCars.add(cars.get(i));
        }
        return resultCars;
    }
}
