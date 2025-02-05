package org.example.Services;

import org.example.models.Car;
import java.util.*;
public class SearchContext {
    private ISearchStrategy searchStrategy;

    public SearchContext(ISearchStrategy searchStrategy) {
        this.searchStrategy = searchStrategy;
    }

    public List<Car> search(List<Car> cars, Object searchType)
    {
        return searchStrategy.search(cars, searchType);
    }
}
