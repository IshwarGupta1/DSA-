package org.example.Services;

import org.example.models.*;

import java.util.*;

public class RegistrationService implements IRegistrationService{
    private IPaymentStrategy paymentStrategy = null;
    @Override
    public void RegisterCustomer(HashMap<Customer, HashSet<Car>> customerList, Customer customer) {
        if(customerList.containsKey(customer))
            throw new IllegalArgumentException("customer already exists");
        customerList.put(customer, new HashSet<Car>());
        System.out.println("customer has been registered to the system");
        return;
    }

    @Override
    public void UnRegisterCustomer(HashMap<Customer, HashSet<Car>> customerList, Customer customer, String paymentMode) {
        if(customerList.containsKey(customer))
            throw new IllegalArgumentException("customer does not exists in the system");
        HashSet<Car> carsList = customerList.get(customer);
        if(carsList.size()==0)
        {
            customerList.remove(customer, carsList);
            System.out.println("customer has been unregistered from the system");
            return;
        }
        System.out.println("Please clear your dues");
        Iterator<Car> carIterator = carsList.iterator();
        while(carIterator.hasNext()) {
            Car car = carIterator.next();
            System.out.println("Payment for car " + car.getModel() + " " + car.getModel());
            double rentPerDay = car.getRentPerDay();
            int bookedDays = car.getBookedDays();
            double amounttobePaid = rentPerDay * bookedDays;
            switch (paymentMode) {
                case "CC":
                    paymentStrategy = new CCPaymentStrategy("1234-5678-90123", "Ishwar");
                    break;
                case "UPI":
                    paymentStrategy = new UPIPaymentStrategy("ishwar@upi");
                    break;
                case "Cash":
                    paymentStrategy = new CashPaymentStrategy();
                    break;
                default:
                    throw new IllegalArgumentException("Payment mode not available");
            }
            PaymentContext payContext = new PaymentContext(paymentStrategy);
            payContext.payment(amounttobePaid);
            car.setIsAvailable(Status.Available);
            carsList.remove(car);
        }
        return;
    }
}
