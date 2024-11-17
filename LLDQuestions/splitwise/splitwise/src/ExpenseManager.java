import java.util.*;

public class ExpenseManager {
    private Map<Integer, Group> groups;
    private Map<Integer, Expense> expenses;
    private Map<Integer, User> users;

    public ExpenseManager() {
        this.groups = new HashMap<>();
        this.expenses = new HashMap<>();
        this.users = new HashMap<>();
    }

    // Add user to the system
    public void addUser(User user) {
        users.put(user.UserId, user);
    }

    // Create a new group
    public Group createGroup(int groupId, String groupName, List<User> members) {
        Group group = new Group(groupId, groupName, members);
        for (User member : members) {
            addUser(member);  // Make sure each member is added to the system
        }
        groups.put(groupId, group);
        return group;
    }

    // Add a user to an existing group
    public void addUserToGroup(int groupId, User user) {
        Group group = groups.get(groupId);
        if (group != null) {
            group.addUser(user);
        }
    }

    // Create a new expense (for different types like Equal, Exact, Percentage)
    public Expense createExpense(int expenseId, String expenseName, double amount, User paidBy, SplitType type, List<Share> shares) {
        Expense expense = null;
        switch (type) {
            case Equal:
                expense = new EqualExpense(expenseId, expenseName, amount, paidBy, shares);
                break;
            case Exact:
                expense = new ExactExpense(expenseId, expenseName, amount, paidBy, shares);
                break;
            case Percentage:
                expense = new PercentageExpense(expenseId, expenseName, amount, paidBy, shares);
                break;
            default:
                throw new IllegalArgumentException("Invalid expense type");
        }
        expenses.put(expenseId, expense);
        return expense;
    }

    // Get an existing expense by its ID
    public Expense getExpense(int expenseId) {
        return expenses.get(expenseId);
    }

    // Validate an expense
    public boolean validateExpense(int expenseId) {
        Expense expense = expenses.get(expenseId);
        if (expense != null) {
            return expense.Validate();
        }
        return false;
    }

    // Calculate the amount each user owes in a group for an expense
    public Map<User, Double> calculateOwedAmount(int expenseId) {
        Expense expense = expenses.get(expenseId);
        Map<User, Double> owedAmounts = new HashMap<>();
        if (expense != null) {
            for (Share share : expense.shares) {
                owedAmounts.put(share.user, share.amount);
            }
        }
        return owedAmounts;
    }

    // Get a list of all users in the system
    public List<User> getAllUsers() {
        return new ArrayList<>(users.values());
    }

    // Get a list of all groups
    public List<Group> getAllGroups() {
        return new ArrayList<>(groups.values());
    }

    // Get a list of all expenses
    public List<Expense> getAllExpenses() {
        return new ArrayList<>(expenses.values());
    }
}
