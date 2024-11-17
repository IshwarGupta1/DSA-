import java.util.*;
public abstract class Expense {
    int expenseId;
    String expenseName;
    double amount;
    User paidBy;
    SplitType type;
    List<Share> shares;

    public Expense(int expenseId, String expenseName, double amount, User paidBy, SplitType type, List<Share> shares) {
        this.expenseId = expenseId;
        this.expenseName = expenseName;
        this.amount = amount;
        this.paidBy = paidBy;
        this.type = type;
        this.shares = shares;
    }
    public abstract boolean Validate();
}
