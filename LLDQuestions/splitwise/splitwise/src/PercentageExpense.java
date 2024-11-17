import java.util.*;
public class PercentageExpense extends Expense {
    public PercentageExpense(int expenseId, String description, double amount, User paidBy, List<Share> shares) {
        super(expenseId, description, amount, paidBy, SplitType.Percentage, shares);
    }

    @Override
    public boolean Validate() {
        if(shares.size()<=0)
            return false;
        double totalPercentage=0.0;
        for(int i=0;i<shares.size();i++)
        {
            totalPercentage = totalPercentage + ((shares.get(i).amount/amount)*100.0);
        }
        return (100.0-totalPercentage)<=0.01;
    }
}