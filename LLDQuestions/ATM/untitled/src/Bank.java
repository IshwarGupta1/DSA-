import java.util.*;
public class Bank {
    public Map<User, Account> customers;

    public Bank(Map<User, Account> customers) {
        this.customers = customers;
    }

    public void withdrawMoney(User user, ATMMachine atm, double amount) {
        if (!customers.containsKey(user)) {
            throw new RuntimeException("User not a customer of this bank");
        }
        if (user.account.accountBalance < amount) {
            throw new RuntimeException("Insufficient balance");
        }

        user.account.accountBalance -= amount;
        System.out.println(amount + " withdrawn");
    }

    public void depositMoney(User user, ATMMachine atm, double amount) {
        if (!customers.containsKey(user)) {
            throw new RuntimeException("User not a customer of this bank");
        }

        user.account.accountBalance += amount;
        System.out.println(amount + " deposited");
    }

    public void transferMoney(User user, ATMMachine atm, User toUser, double amount) {
        if (!customers.containsKey(user) || !customers.containsKey(toUser)) {
            throw new RuntimeException("One or both users are not customers of this bank");
        }

        toUser.account.accountBalance += amount;
        System.out.println(amount + " transferred to " + toUser.userName);
    }

    public void balanceInquiry(User user, ATMMachine atm) {
        if (!customers.containsKey(user)) {
            throw new RuntimeException("User not a customer of this bank");
        }

        System.out.println("Balance: " + user.account.accountBalance);
    }
}
