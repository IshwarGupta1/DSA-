package org.example.Services;
import org.example.models.*;
import java.util.*;
public interface ISearchStrategy {
    public List<Car> search(List<Car> cars, Object searchType);
}
