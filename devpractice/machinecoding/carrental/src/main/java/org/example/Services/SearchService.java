package org.example.Services;

import org.example.models.*;

import java.util.*;

public class SearchService {
    private ISearchStrategy searchStrategy = null;
    public List<Car> search(List<Car> carsList, Object searchTerm, SearchType searchType)
    {
        List<Car> resultCarList = new ArrayList<Car>();
        switch (searchType){
            case Amount:
                searchStrategy = new SearchByPriceStrategy();
                //resultCarList =  searchStrategy.search(carsList, searchTerm);
                break;
            case Model:
                searchStrategy = new SearchByModelStrategy();
                //resultCarList =  searchStrategy.search(carsList, searchTerm);
                break;
            case Availability:
                searchStrategy = new SearchByAvailability();
                //resultCarList =  searchStrategy.search(carsList, searchTerm);
                break;
        }
        SearchContext searchContext = new SearchContext(searchStrategy);
        searchContext.search(carsList, searchTerm);
        return resultCarList;
    }
}
