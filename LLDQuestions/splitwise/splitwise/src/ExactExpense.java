import java.util.*;
public class ExactExpense extends Expense {
    public ExactExpense(int expenseId, String description, double amount, User paidBy, List<Share> shares) {
        super(expenseId, description, amount, paidBy, SplitType.Exact, shares);
    }

    @Override
    public boolean Validate() {
        if(shares.size()<=0)
            return false;
        double sum=0;
        for(int i=0;i<shares.size();i++)
        {
            sum=sum+shares.get(i).amount;
        }
        return sum==amount;
    }
}