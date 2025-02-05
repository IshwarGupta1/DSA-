package org.example.Services;

import org.example.models.*;

import java.util.List;

public interface ISearchService{
    List<Car> search(List<Car> carsList, Object searchTerm, SearchType searchType);
}
