package org.example.Services;

import org.example.models.*;

import java.util.HashMap;
import java.util.HashSet;

public interface IRegistrationService {
    public void RegisterCustomer(HashMap<Customer, HashSet<Car>> customerList, Customer customer);
    public void UnRegisterCustomer(HashMap<Customer, HashSet<Car>> customerList, Customer customer, String paymentMode);
}
