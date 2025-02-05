package org.example;

import org.example.Services.IRegistrationService;
import org.example.Services.ISearchService;
import org.example.models.*;

import java.util.*;

public class RentalSystem {
    private List<Car> carsList;
    private HashMap<Customer, HashSet<Car>> customerList;
    private IRegistrationService registrationService;
    private ISearchService searchService;
    public void RegisterCustomer(Customer customer)
    {
        registrationService.RegisterCustomer(customerList, customer);
    }
    public void UnRegisterCustomer(Customer customer, String modeofPayment)
    {
        registrationService.UnRegisterCustomer(customerList, customer, modeofPayment);
    }

    public List<Car> search(Object searchTerm, SearchType searchType)
    {
        return searchService.search(carsList, searchTerm, searchType);
    }
}
