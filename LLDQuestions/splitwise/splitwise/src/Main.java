import java.util.*;
public class Main {
    public static void main(String[] args) {
        ExpenseManager manager = new ExpenseManager();

        // Create users
        User user1 = new User(1, "John");
        User user2 = new User(2, "Jane");

        // Add users to the manager
        manager.addUser(user1);
        manager.addUser(user2);

        // Create a group
        List<User> members = Arrays.asList(user1, user2);
        Group group = manager.createGroup(1, "Friends", members);

        // Create shares for the expense
        List<Share> shares = Arrays.asList(new Share(user1, 50), new Share(user2, 50));

        // Create an equal expense
        Expense expense = manager.createExpense(1, "Dinner", 100, user1, SplitType.Equal, shares);

        // Validate the expense
        boolean isValid = manager.validateExpense(1);
        System.out.println("Expense is valid: " + isValid);

        // Calculate what each user owes
        Map<User, Double> owedAmounts = manager.calculateOwedAmount(1);
        for (Map.Entry<User, Double> entry : owedAmounts.entrySet()) {
            System.out.println(entry.getKey().UserName + " owes: " + entry.getValue());
        }
    }
}
