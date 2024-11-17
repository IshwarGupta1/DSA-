import java.util.*;
public class EqualExpense extends Expense {
    public EqualExpense(int expenseId, String description, double amount, User paidBy, List<Share> shares) {
        super(expenseId, description, amount, paidBy, SplitType.Equal, shares);
    }

    @Override
    public boolean Validate() {
        if(shares.size()<=0)
            return false;
        double amountperHead = amount/shares.size();
        for(int i=0;i<shares.size();i++)
        {
            if(shares.get(i).amount != amountperHead)
                return false;
        }
        return true;
    }
}